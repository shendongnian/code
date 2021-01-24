            public IActionResult SignIn(string provider, string returnUrl)
        {
            var properties = signInManager.ConfigureExternalAuthenticationProperties("Facebook", Url.Action("ExternalLoginCallback", "Account", new { returnUrl = returnUrl}));
            return Challenge(properties, "Facebook");
        }
