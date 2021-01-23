        public ActionResult Profile()
        {
            var app = new FacebookApp();
            if (app.Session == null)
            {
                // The user isnt logged in to Facebook
                // send them to the home page
                return RedirectToAction("Index");
            }
	    // Read current access token:
            var accessToken = app.Session.AccessToken;
            // Get the user info from the Graph API
            dynamic me = app.Api("/me");
            ViewData["FirstName"] = me.first_name;
            ViewData["LastName"] = me.last_name;
            return View();
        }
