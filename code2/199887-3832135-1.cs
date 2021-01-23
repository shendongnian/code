    public static byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
    {
      DES des = new DES();
      des.BlockSize = 128;
      des.Mode = CipherMode.CBC;
      des.Padding = PaddingMode.Zeros;
      des.IV = IV
      des.Key = key
      ICryptoTransform encryptor = des.CreateEncryptor();
    
      //and finaly operations on bytes[] insted of streams
      return encryptor.TransformFinalBlock(plaintextarray,0,plaintextarray.Length);
    }
