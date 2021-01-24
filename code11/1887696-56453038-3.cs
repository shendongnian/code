    [HttpPost("login")]
    public async Task<IActionResult> Login(UserForLoginDto user)
    {
        var userFromRepo = await _qrepo.Login(user.Username, user.Password);
        //IF no user found in db
        if (userFromRepo == null)
            //Return unauth so if user have wrong login creds, we're not specifying if it's password or username
            return Unauthorized();
        //Injected ITokenGenerator (note the interface)
        var token = _tokenGenerator.GenerateToken(userFromRepo);
        // Return actual token
        return Ok(new
        {
            token
        });
    }
