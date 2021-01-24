    [HttpGet]
    [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
    public async Task<IActionResult> ConfirmEmail(string userId = "", string code = "")
    {
        //....
        IdentityResult result = await UserManager.ConfirmEmailAsync(userId, code);
        if (result.Succeeded)
        {
            return Ok();
        }
        else
        {
            return BadRequest("An error occurred confirming the given email-address.");
        }
    }
