    User user = (from u in db.Users 
         where u.Username.Equals(username)
         select u).FirstOrDefault();
    if  (user == null)
    {
      // Invalid user name
    }
    else if (!user.password.Equals(...))
    {
      // Invalid password
    }
    else if (user.Status != true)
    {
      // User inactive
    }
    else
    {
      // Success
    }
