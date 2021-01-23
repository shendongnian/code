    public static bool IsUserExists(string userName, string hashedPassword)
    {
      bool result = false;
    
      using (MyEntities entityContext = new MyEntities())
      {
        result = (entityContext.User.Count(u => u.username == userName && 
                                                u.password == hashedPassword) == 1);
      }
    
      return result;
    }
