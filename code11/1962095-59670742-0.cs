    if (ModelState.IsValid)
    {
        //Create application user
        var user = new ApplicationUser { UserName = registerAsReqModel.UserName, Email = registerAsReqModel.EmailAddress };
        //assgin user to user type
        user.UserType = "Req";
        var result1 = db.Users.Where(m => m.UserName.Equals(registerAsReqModel.UserName)).FirstOrDefault();
        var result2 = db.Users.Where(m => m.Email.Equals(registerAsReqModel.EmailAddress)).FirstOrDefault();
        
        var result3 = from app in db.Users where app.UserType.Equals("Req") && app.Email.Equals(registerAsReqModel.EmailAddress) && app.UserName.Equals(registerAsReqModel.UserName) select app;
        // 
        if (result3 == null)
        {
            UserManager.UserValidator = new UserValidator<ApplicationUser>(UserManager)
            {
                RequireUniqueEmail = false,
            };
            var result = await UserManager.CreateAsync(user, registerAsReqModel.Password);
            if (result.Succeeded)
            {
                await UserManager.AddToRoleAsync(user.Id, "Req");
                db.RegisterAsReqModels.Add(registerAsReqModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            AddErrors(result);
        }
        else if ((result1 != null) && (result2 != null))
        {
            StringBuilder sb = new StringBuilder();
            if (result2 != null)
            {
                sb.AppendLine("Email Address Exists!");
            }
            else
            {
                sb.AppendLine("UserName  Exists!");
            }
            ModelState.AddModelError("", sb.ToString());
        }
    }
