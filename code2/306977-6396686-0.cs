      byte[] key = Convert.FromBase64String("EajmplPP8DHg6Tqq8BVRMw==");
      byte[] encryptedData = Convert.FromBase64String("CLbtkjNkcofJ5D8s4Ri7nA==");
      
      Aes aes = Aes.Create();
      aes.Mode = CipherMode.ECB;
      using (var ms = new MemoryStream())
      {
        using (var cs = new CryptoStream(ms, aes.CreateDecryptor(key, null), CryptoStreamMode.Write))
        {
          cs.Write(encryptedData, 0, encryptedData.Length);
        }
        byte[] decryptedData = ms.ToArray();
        string clearText = Encoding.ASCII.GetString(decryptedData);
        Console.WriteLine(clearText);
      }
