`
// Redirect to ~/Account/SignOut after signing out.
     
   string callbackUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Response.ApplyAppPathModifier("~/Account/SignOut");
        HttpContext.Current.GetOwinContext().Authentication.SignOut(
            new AuthenticationProperties { RedirectUri = callbackUrl },
            WsFederationAuthenticationDefaults.AuthenticationType,
            CookieAuthenticationDefaults.AuthenticationType);
