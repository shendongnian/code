    [AllowAnonymous]
    [Route("api/authenticate")] // <-- Here it is
    [HttpPost]
    public async Task<IActionResult> Authenticate([FromBody] LoginViewModel model)
    {
         .........
    }
    [Route("api/JWTStatus")] // <-- Here it is
    [HttpGet]
    public IActionResult GetJwtStatus() 
    {
        .......
    }
