    //needed to convert from hex string
    public static byte[] FromHexString(string hexString)
    {
      int NumberChars = hexString.Length;
      byte[] bytes = new byte[NumberChars / 2];
      for (int i = 0; i < NumberChars; i += 2)
        bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
      return bytes;
    }
    [TestMethod]
    public void Test()
    {
      string toEncryptString = "24.9195N 17.821E";
      //initialise key and IV (note - all zero IV is not recommended!)
      byte[] key = FromHexString("0123456789abcdef0123456789abcdef");
      byte[] iv = FromHexString("00000000000000000000000000000000");
      byte[] toEncrypt = System.Text.Encoding.UTF8.GetBytes(toEncryptString);
      byte[] cipherBytes = null;
      string cipherText = null;
      //encrypt
      using (System.Security.Cryptography.Rijndael r = new RijndaelManaged())
      {
        r.Key = key;
        r.IV = iv;
        using(System.Security.Cryptography.ICryptoTransform transform 
          = r.CreateEncryptor())
        {
          using (var mStream = new System.IO.MemoryStream())
          {
            using (var cStream = 
              new CryptoStream(mStream, transform, CryptoStreamMode.Write))
            {
              cStream.Write(toEncrypt, 0, toEncrypt.Length);
              cStream.FlushFinalBlock();
              cipherBytes = mStream.ToArray();
              cipherText = Convert.ToBase64String(cipherBytes);
            }
          }
        }
      }
      //decrypt
      byte[] toDecrypt = Convert.FromBase64String(cipherText);
      string decryptedString = null;
      using (System.Security.Cryptography.Rijndael r = new RijndaelManaged())
      {
        r.Key = key;
        r.IV = iv;
        using(System.Security.Cryptography.ICryptoTransform transform2
          = r.CreateDecryptor()) // <-- difference here
        {
          using (var mStream2 = new System.IO.MemoryStream())
          {
            using (var cStream2 = 
              new CryptoStream(mStream2, transform2, CryptoStreamMode.Write))
            {
              cStream2.Write(toDecrypt, 0, toDecrypt.Length);
              cStream2.FlushFinalBlock();
              decryptedString = 
                System.Text.Encoding.UTF8.GetString(mStream2.ToArray());
            }
          }
        }
      }
      Assert.AreEqual(toEncryptString, decryptedString);
    }
