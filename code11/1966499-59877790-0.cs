    // POST api/Account/Register
    [AllowAnonymous]
    [HttpPost]
    [Route("Register")]
    public async Task<IHttpActionResult> Register(RegisterBindingModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };
        IdentityResult result = await UserManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            return GetErrorResult(result);
        }
        return Ok();
    }
