     string hashedFields = ComputeSha256HashHex(authToken + password + devId);
    
     string encryptedString = AesEncryptToBase64String(saltString + orgId + "=" + hashedFields, secretKey);
               
            private string AesEncryptToBase64String(string plainText, string key)
            {
                // Convert string arguments into byte arrays
                byte[] keyBytes = Encoding.ASCII.GetBytes(key);
                byte[] plainTextBytes = Encoding.ASCII.GetBytes(plainText);
    
                // Check arguments.
                if (plainText == null || plainText.Length <= 0)
                    throw new ArgumentNullException("plainText");
                if (key == null || key.Length <= 0)
                    throw new ArgumentNullException("key");
                byte[] encrypted;
    
                // Create an Aes object
                // with the specified key and IV.
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = keyBytes;
                    aesAlg.Padding = PaddingMode.PKCS7;
                    aesAlg.Mode = CipherMode.ECB;
    
                    // Create an encryptor to perform the stream transform.
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor();
    
                    // Create the streams used for encryption.
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                swEncrypt.Write(plainText);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }
    
                // Return encrypted bytes as Base 64 string
                return Convert.ToBase64String(encrypted);
            }
    
    
            private string ComputeSha256HashHex(string plainText)
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));
    
                    // Convert byte array to a string   
                    return BytesToHexString(bytes);
                }
            }
    
    
            private string BytesToHexString(byte[] bytes)
            {
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
