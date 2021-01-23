         static string DecryptStringFromBytes(byte[] cipherText, byte[] key)
         {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            
            string plaintext;
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.BlockSize = 256;
                rijAlg.Key = key;
                rijAlg.Mode = CipherMode.ECB;
                rijAlg.Padding = PaddingMode.Zeros;
                rijAlg.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                using (var msDecrypt = new MemoryStream(cipherText))
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        using (var srDecrypt = new StreamReader(csDecrypt))
                            plaintext = srDecrypt.ReadToEnd();
            }
            return plaintext;
        }
        
