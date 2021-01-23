    User user = (from u in db.Users 
         where u.Username.Equals(username) &&   
               u.Password.Equals(UserSecurity.GetPasswordHash(username, password))
         select u).FirstOrDefault(); 
 
    if (user == null)
    {
      // Invalid user name or password
    }
    else if (user.Status != true)
    {
      // User inactive
    }
    else
    {
      // Success
    }
{
