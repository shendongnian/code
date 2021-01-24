    private static byte[] DecryptBytesFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
    {
      if ((cipherText == null) || (cipherText.Length <= 0))
      {
        throw (new ArgumentNullException("cipherText"));
      }
      if ((Key == null) || (Key.Length <= 0))
      {
        throw (new ArgumentNullException("Key"));
      }
      RijndaelManaged rijAlg = new RijndaelManaged();
      rijAlg.Key = Key;
      if (!(IV == null))
      {
        if (IV.Length > 0)
        {
          rijAlg.IV = IV;
        }
        else
        {
          rijAlg.Mode = CipherMode.ECB;
        }
      }
      else
      {
        rijAlg.Mode = CipherMode.ECB;
      }
      ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
      return decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
    }
