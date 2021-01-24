    [Route("login")]
    [HttpPost]
    public async Task<ActionResult> LoginAsync(string username, string password)
    {
        await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
           var result = await mSignInManager.PasswordSignInAsync(username, password, true, false);
        
            if (result.Succeeded)
            {
                return Ok(user); // your object
            }
        
            return NotFound();
        }
