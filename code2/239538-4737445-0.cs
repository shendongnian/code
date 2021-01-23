    [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    LoadProfile(model.UserName);
                }
         }
         private void LoadProfile(string UserName)
         {
              MyModelContext ctx = new MyModelContext(); //EF or LINQ2SQL context
              var user = ctx.Users.Where(u => u.UserName == UserName).FirstOrDefault();
              Session.Add("CurrentUser", user);
         }
