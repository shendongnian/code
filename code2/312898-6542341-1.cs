    private void FindWhatsFailing(string password) //password = Whatever you're passing in to verify BCrypt is working
    {
      const string expectedpassword = "Qwerty123";
      if(expectedpassword != password)
      {
          Debug.WriteLine("My password isn't what I thought it was");
          return;
      }
      string hashed = BCrypt.HashPassword(expectedpassword , BCrypt.GenerateSalt(12));
      if(!BCrypt.Verify(expectedpassword , hashed))
      {
         Debug.WriteLine("Something is wrong with BCrypt");
         return;
      }
      /// ... Test hashing password, compare to hash of expectedpassword, verify password against hash of itself and expectedpassword
     Debug.WriteLine("Everything worked, maybe the database storage is off?");
    }
