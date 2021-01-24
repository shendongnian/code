      public static string AesEncrypt(string plainText, byte[] Key, byte[] IV)
        {
             // Create an Aes object with the specified key and IV
             using Aes aesAlg = Aes.Create();
             aesAlg.Key = Key;
             aesAlg.IV = IV;
        
             // Create an encryptor to perform the stream transform
             ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
        
             // Create the streams used for encryption
             using MemoryStream msEncrypt = new MemoryStream();
             using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
             using (StreamWriter swEncrypt = new StreamWriter(csEncrypt)) {
                 // Write all data to the stream
                 swEncrypt.Write(plainText);
             }
        
             return Encoding.UTF8.GetString(msEncrypt.ToArray());
        
        }
