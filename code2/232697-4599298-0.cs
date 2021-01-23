        /// <summary>
        /// DES Encryption method - used to encryp password for the java.
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string EncryptData(string plainText)
        {
            DES des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
            des.Key = Encoding.UTF8.GetBytes(_secretPhrase.Substring(0, 8));
            des.IV = Encoding.UTF8.GetBytes(_secretPhrase.Substring(0, 8));
            byte[] bytes = Encoding.UTF8.GetBytes(plainText);
            byte[] resultBytes = des.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
            return Convert.ToBase64String(resultBytes);
        }
        /// <summary>
        /// DES Decryption method - used the decrypt password encrypted in java
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <returns></returns>
        public string DecryptData(string encryptedText)
        {
            DES des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
            des.Key = Encoding.UTF8.GetBytes(_secretPhrase.Substring(0, 8));
            des.IV = System.Text.Encoding.UTF8.GetBytes(_secretPhrase.Substring(0, 8));
            byte[] bytes = Convert.FromBase64String(encryptedText);
            byte[] resultBytes = des.CreateDecryptor().TransformFinalBlock(bytes, 0, bytes.Length);
            return Encoding.UTF8.GetString(resultBytes);
        }
