    public LoginViewModel()
    {
      [Required]
      public string LoginId {get; set;}
      
      [DataType(DataType.Password)]
      public string Password {get; set;}
      
      [DataType(DataType.Password)]
      public string ConfirmPassword {get; set;}
    
     // this validation is not db related and can be done client side...
     public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string regex1 = @"^.{8,10}$";                   // 8 - 10 characters
    
            Match requirement1 = Regex.Match(Password, regex1);
    
            if (Password != ConfirmPwd)
                yield return new ValidationResult("Password and Confirm Password is not identical.");
    
            if (!requirement1.Success)
                yield return new ValidationResult("Password must be between 8 and 10 characters.");
    
    
        }
    
    }
    
    [HttpGet]
    public ActionResult Login()
    {
       var model = new LoginViewModel();
       
       return View("Login",model);
    }
    
    [HttpPost]
    public ActionResult Login(LoginViewModel model)
    {
      
       var user = GetUserFromRepositoryByUsername(model.username);
    
       if(user != null)
        {
          if(user.password == model.Password)
          {
            RedirectToAction("YouLoggedInYay!");
          }
        }
    
        // if we made it this far, the user didn't exist or the password was wrong.
        // Highlight the username field red and add a validation error message.
        ModelState.AddError("Username","Your credentials were invalid punk!");
       
       return View("Login",model);
    }
