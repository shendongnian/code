    public ActionResult IsUserExists(string userName) 
    {
     if (!UserService.UserNameExists(userName) || (CurrentUser.UserName == userName))
     {
          return "Ok.";
     }
    }
