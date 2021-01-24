    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult<string>> Get()
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        return token;
    }
