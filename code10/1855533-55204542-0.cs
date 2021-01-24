    [HttpGet("/api/profile")]
    public async Task < IActionResult > Index() {
    
       var userId = caller.Claims.Single(c => c.Type == ClaimTypes.Name);
       var user = await userManager.Users.Include(s => s.Sex)
                  .SingleOrDefaultAsync(c => c.Id == userId.Value);
    
        return Ok(user);
    
    }    
