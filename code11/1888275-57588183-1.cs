    [HttpGet("/MyApplication")]
            [AllowAnonymous]
            public async Task<IActionResult> Login(string returnUrl = null)
            {
                // Clear the existing external cookie to ensure a clean login process
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
    
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }
