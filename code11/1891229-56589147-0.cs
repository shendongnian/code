    public static string CreateValidPassword(int longitud, string usuario)
    {
      while(true)
      {
        var password = CreateRandomPassword(longitud, usuario);
        if (ValidPassword(password)) 
          return password;
      }
    }
    public static string CreateRandomPassword(int longitud, string usuario)
    { 
      // Create a random password **CORRECTLY THIS TIME**
    }
