    [HttpPost]
    public ActionResult Login([FromBody]LoginModel GetLoginData)
    {
      /// Get SAM and Passowrd
      var service = new JSON();
      var LoginUser = service.GetData(GetLoginData);
      _logger.Log(LogLevel.Information, $"User {LoginUser.SAM} tried to Login.");
      /// Checks if user is allowed to login
      var db = new DB();
      bool IsAllowed = db.GetUserBySAM(LoginUser);
      if (IsAllowed == true)
      {
        /// Checks if Password is correct in LDAP
        var ldap = new LDAP();
        bool PasswordCorrect = ldap.IsUserPasswordCorrect(LoginUser);
        if (PasswordCorrect == true)
        {
          /// Gets Userdata from AD
          LoginUser = ldap.GetUserData(LoginUser);
          var auth = new Authentication();
          /// Generates a Token which expire in 5 minutes
          var JwtToken = auth.CreateToken(LoginUser);
          _logger.Log(LogLevel.Information, $"User {LoginUser.SAM} successfully logged in.");
          return Ok(new
          {
            token = JwtToken,
            allowed = "Authorized",
            username = LoginUser.SAM,
            firstname = LoginUser.FirstName,
            lastname = LoginUser.LastName
          });
        }
        else return Unauthorized();
      }
      _logger.Log(LogLevel.Information, $"User {LoginUser.SAM} is not allowed to login.");
      return Unauthorized();
    }
