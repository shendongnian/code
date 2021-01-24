    public async Task<ActionResult> Register()
    {
      try
      {
        var model = (RegisterUserModel)Session["RegisterAccount"];
        var user = new AspNetUser()
        {
          UserName = model.Email,
          Email = model.Email
        };
        var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        IdentityResult addUserResult = await userManager.CreateAsync(user, model.Password);
    
        if (!addUserResult.Succeeded)
        {
          //loop over addUserResult.Errors for more detail
        }
      }
      catch (Exception exception)
      {
        //here, check the exception for more details
      }
    }
