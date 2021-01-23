     Encoding stringEncoding = new System.Text.UTF8Encoding();
            byte[] salt = new byte[8];
            new RNGCryptoServiceProvider().GetBytes(salt);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.Mode = cipherMode;
            aes.KeySize = keySize;
            aes.Key = stringEncoding.GetBytes(password);
            aes.IV = new byte[aes.IV.Length];
            // Overestimate encrypted size requirements 
            byte[] encryptedDataBuffer = new byte[plainText.Length + 32 + 32 + 8];
            MemoryStream encryptedOutput = new MemoryStream(encryptedDataBuffer, true);
            CryptoStream encStream = new CryptoStream(encryptedOutput, aes.CreateEncryptor(),
                                                      CryptoStreamMode.Write);
            encStream.Write(plainText, 0, plainText.Length);
            encStream.FlushFinalBlock();
            byte[] encryptedData = new byte[encryptedOutput.Position];
            Array.Copy(encryptedDataBuffer, encryptedData, encryptedData.Length);
            encStream.Close();
            
            return encryptedData;
