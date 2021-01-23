    static byte[] GenerateSaltedHash(string password, byte[] salt)
    {
      byte[] plainText = Encoding.UTF8.GetBytes(password);
      HashAlgorithm algorithm = new SHA256Managed();
    
      byte[] plainTextWithSaltBytes = 
        new byte[plainText.Length + salt.Length];
    
      for (int i = 0; i < plainText.Length; i++)
      {
        plainTextWithSaltBytes[i] = plainText[i];
      }
      for (int i = 0; i < salt.Length; i++)
      {
        plainTextWithSaltBytes[plainText.Length + i] = salt[i];
      }
    
      byte[] hash = algorithm.ComputeHash(plainTextWithSaltBytes);            
    }
