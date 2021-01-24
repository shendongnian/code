    var code = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
    var callbackUrl = Url.Action(
                            "ConfirmEmail",
                            "Account",
                            new { userId = identityUser.Id, code = code },
                            protocol: HttpContext.Request.Scheme);
    
    await emailService.SendEmailAsync(model.Email, "Confirm your account",
                            $"confirm email: <a href='{callbackUrl}'>link</a>");
