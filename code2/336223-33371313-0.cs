        public static class EncryptionExample
    {
        #region internal consts
        internal const string passPhrase = "pass";
        internal const string saltValue = "salt";
        internal const string hashAlgorithm = "MD5";
        internal const int passwordIterations = 3;             // can be any number
        internal const string initVector = "0123456789abcdf"; // must be 16 bytes
        internal const int keySize = 64;                      // can be 192 or 256
        #endregion
        #region public static Methods
        public static string Encrypt(string data)
        {
            string res = string.Empty;
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(initVector);
                byte[] rgbSalt = Encoding.ASCII.GetBytes(saltValue);
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                byte[] rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
                RijndaelManaged managed = new RijndaelManaged();
                managed.Mode = CipherMode.CBC;
                ICryptoTransform transform = managed.CreateEncryptor(rgbKey, bytes);
                byte[] inArray = null;
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, transform, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(buffer, 0, buffer.Length);
                        csEncrypt.FlushFinalBlock();
                        inArray = msEncrypt.ToArray();
                        res = Convert.ToBase64String(inArray);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Encrypt " + ex);
            }
            return res;
        }
        public static string Decrypt(string data)
        {
            string res = string.Empty;
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(initVector);
                byte[] rgbSalt = Encoding.ASCII.GetBytes(saltValue);
                byte[] buffer = Convert.FromBase64String(data);
                byte[] rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
                RijndaelManaged managed = new RijndaelManaged();
                managed.Mode = CipherMode.CBC;
                ICryptoTransform transform = managed.CreateDecryptor(rgbKey, bytes);
                using (MemoryStream msEncrypt = new MemoryStream(buffer))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msEncrypt, transform, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            res = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine("Decrypt " + ex);
            }
            return res;
        }
    }
