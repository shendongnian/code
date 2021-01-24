    [AllowAnonymous]
    [HttpPost(nameof(Authenticate))]
    public IActionResult Authenticate([FromBody] UserModel userParams)
    {
        var authenticate = _authenticationService.Authenticate(userParams.Username, userParams.Password);
        return Ok("");
    }
