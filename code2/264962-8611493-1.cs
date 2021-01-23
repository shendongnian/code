    List<User> UsersCopy = new List<User>();
    foreach(user in Users){
      User u = new User();
      u.UserName = user.UserName;
      u.Address = user.Address;
      //...
      UsersCopy.Add(u);
    }
    return View(UsersCopy);
