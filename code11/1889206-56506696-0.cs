    public async Task<ActionResult> LoginAsync(string username, string password)
    {
        await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
        var result = await mSignInManager.PasswordSignInAsync(username, password, true, false);
        if (result.Succeeded)
        {
            return new JsonResult("Succeeded", new JsonSerializerSettings());
            // or return new[] { user.DisplayName, user.Role };
        }
        return Content("Failed");
    }
