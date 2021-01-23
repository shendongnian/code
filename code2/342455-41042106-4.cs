    public ActionResult callback()
    {
        // Here we skip all the error handling and null checking
        var auth = HttpContext.GetOwinContext().Authentication;
        var loginInfo = auth.GetExternalLoginInfo();
        var identityInfo = auth.GetExternalIdentity(DefaultAuthenticationTypes.ExternalCookie);
        var email = loginInfo.Email // klaatuveratanecto@gmail.com
        var name = loginInfo.ExternalIdentity.Name  // Klaatu Verata Necto
        var provider = loginInfo.Login.LoginProvider // Facebook | Google
         
        var fb_access_token = loginInfo.identityInfo.FindFirstValue("FacebookAccessToken");
        // Save this token to database, for the purpose of this example we will save it to Session.
        Session['fb_access_token'] = fb_access_token;
        // ...                   
    }
