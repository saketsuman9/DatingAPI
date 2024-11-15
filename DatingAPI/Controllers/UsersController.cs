﻿using DatingAPI.Data;
using DatingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Controllers
{
    [Route("api/[controller]")] // /api/users
    [ApiController]
    public class UsersController(DataContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await context.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id:int}")] // /api/users/2
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null) return NotFound();

            return user;
        }
    }
}
