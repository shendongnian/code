    [HttpGet("test1/{username}"), AllowAnonymous]
    public IActionResult GetStuff(string userName)
    {   
      return Ok(Context.Members
        .Include(e => e.Tenant)
        .Single(e => e.UserName == userName));    
    }
