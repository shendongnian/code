        private static string EncryptString(string Value)
        {
            string ReturnValue = string.Empty;
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(ASCIIEncoding.ASCII.GetBytes("Bermuda"));
            using (TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider())
            {
                provider.Key = TDESKey;
                provider.Mode = CipherMode.ECB;
                provider.Padding = PaddingMode.PKCS7;
                ICryptoTransform Encryptor = provider.CreateEncryptor();
                byte[] ByteValue = ASCIIEncoding.ASCII.GetBytes(Value);
                ReturnValue = Convert.ToBase64String(Encryptor.TransformFinalBlock(ByteValue, 0, ByteValue.Length));
            }
            return ReturnValue;
        }
        private static string DecryptString(string EncryptedValue)
        {
            string ReturnValue = string.Empty;
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(ASCIIEncoding.ASCII.GetBytes("Bermuda"));
            using (TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider())
            {
                provider.Key = TDESKey;
                provider.Mode = CipherMode.ECB;
                provider.Padding = PaddingMode.PKCS7;
                ICryptoTransform Decryptor = provider.CreateDecryptor();
                byte[] ByteValue = Convert.FromBase64String(EncryptedValue);
                ReturnValue = ASCIIEncoding.ASCII.GetString(Decryptor.TransformFinalBlock(ByteValue, 0, ByteValue.Length));
            }
            return ReturnValue;
        }
