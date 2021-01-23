    private string PasswordSalt
    {
       get
       {
          var rng = new RNGCryptoServiceProvider();
          var buff = new byte[32];
          rng.GetBytes(buff);
          return Convert.ToBase64String(buff);
       }
    }
    private string EncodePassword(string password, string salt)
    {
       byte[] bytes = Encoding.Unicode.GetBytes(password);
       byte[] src = Encoding.Unicode.GetBytes(salt);
       byte[] dst = new byte[src.Length + bytes.Length];
       Buffer.BlockCopy(src, 0, dst, 0, src.Length);
       Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
       HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
       byte[] inarray = algorithm.ComputeHash(dst);
       return Convert.ToBase64String(inarray);
    }
