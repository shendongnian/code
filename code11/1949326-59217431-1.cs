    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (!IsValidUsernameAndPasswod(username, password))
            return BadRequest();
    
        var user = GetUserFromUsername(username);
    
        var claimsIdentity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            //...
        }, "Cookies");
    
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        await Request.HttpContext.SignInAsync("Cookies", claimsPrincipal);
    
        return NoContent();
    }
