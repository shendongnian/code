        private static String Encrypt(String Test1, Byte[] Key, Byte[] IV)
        {
            Byte[] Encrypted;
            using (AesCryptoServiceProvider AesMan = new AesCryptoServiceProvider())
            {
                AesMan.Mode              = CipherMode.CBC;
                AesMan.Padding           = PaddingMode.ISO10126;
                ICryptoTransform EncThis = AesMan.CreateEncryptor(Key, IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, EncThis, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(Test1);
                        }
                        Encrypted = msEncrypt.ToArray();
                    }
                }
            };
            return GetString(Encrypted);
        }
        private static String Decrypt(String Data, Byte[] Key, Byte[] IV)
        {
            String Decrypted;
            using (AesCryptoServiceProvider AesMan = new AesCryptoServiceProvider())
            {
                AesMan.Mode              = CipherMode.CBC;
                AesMan.Padding           = PaddingMode.ISO10126;
                ICryptoTransform EncThis = AesMan.CreateDecryptor(Key, IV);
                using (MemoryStream msDecrypt = new MemoryStream(GetBytes(Data)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, EncThis, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream 
                            // and place them in a string.
                            Decrypted = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return Decrypted;
        }
