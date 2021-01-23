    public static string Encrypt(string plaintext, string password)
    {
      return Convert.ToBase64String((new AesManaged {Key = Encoding.UTF8.GetBytes(password)}).CreateEncryptor().TransformFinalBlock(Encoding.UTF8.GetBytes(plaintext), 0, Encoding.UTF8.GetBytes(plaintext).Length));
    }
    public static string Decrypt(string ciphertext, string password)
    {
      return Encoding.UTF8.GetString((new AesManaged { Key = Encoding.UTF8.GetBytes(password) }).CreateDecryptor().TransformFinalBlock(Convert.FromBase64String(ciphertext), 0, Convert.FromBase64String(ciphertext).Length));
    }
