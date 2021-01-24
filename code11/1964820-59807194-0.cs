    public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordViewModel model)
    {
        if (string.IsNullOrEmpty(model.Token) || string.IsNullOrEmpty(model.Email))
        {
            return RedirectToAction("Index", "Error", new { statusCode = AppStatusCode.NotFound });
        }
    
        var isResetTokenValid = await _userManager.CheckValidResetPasswordToken(model.Token, model.Email);
    
        if (!isResetTokenValid || string.IsNullOrEmpty(model.Email))
        {
            return StatusCode(AppStatusCode.ResetPassTokenExpire);
        }
    
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return Ok();
        }
    
        await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
        return Ok();
    }
