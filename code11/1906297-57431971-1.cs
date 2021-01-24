    [HttpGet("test1/{username}"), AllowAnonymous]
    public IActionResult GetStuff(string userName)
    {
      Member output;
    
      output = Context.Members
        .Include(e => e.Tenant)
        .Single(e => e.UserName == userName);
    
      return Ok(output);
    }
