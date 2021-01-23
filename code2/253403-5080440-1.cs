    public ActionResult FBAuthorize()
    {
        FacebookOAuthResult result  = null;
        string url = Request.Url.OriginalString;
        /// hack to make FacebookOuthResult accept the token..
        url = url.Replace("FBAuthorize?", "FBAuthorize#");
        if (FacebookOAuthResult.TryParse(url, out result))
        {
            if (result.IsSuccess)
            {
                string[] extendedPermissions = new[] { "user_about_me", "offline_access" };
                var fb = new FacebookClient(result.AccessToken);
                dynamic resultGet = fb.Get("/me");
                var name = resultGet.name;
                RegisterModel rm = new Models.RegisterModel();
                rm.UserName = name;
                rm.Password = "something";
                rm.Email = "somethig";
                rm.ConfirmPassword = "23213";
                //Label1.Text = name;
                //Response.Write(name);
                //return RedirectToAction("register", "Account", rm);
                ViewData["Register"] = rm;
                return RedirectToAction("Register");
            }
            else
            {
                var errorDescription = result.ErrorDescription;
                var errorReason = result.ErrorReason;
            }
        }
        return View();
    }
