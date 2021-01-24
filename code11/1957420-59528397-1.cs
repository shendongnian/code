public class EncryptHelper
    {
        private static string KeyVal = "put your random string here";
        private static string IvVal = "put your random string here";
        public static string EncryptString(string text)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Key = Encoding.ASCII.GetBytes(KeyVal);
                aes.IV = Encoding.ASCII.GetBytes(IvVal);
                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptString(text, aes.Key, aes.IV);
                return WebUtility.UrlEncode(Convert.ToBase64String(encrypted));
            }
        }
        public static string DecryptString(string base64Str)
        {
            base64Str = WebUtility.UrlDecode(base64Str);
            base64Str = base64Str.Replace(" ", "+");
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Key = Encoding.ASCII.GetBytes(KeyVal);
                aes.IV = Encoding.ASCII.GetBytes(IvVal);
                return DecryptString(
                    Convert.FromBase64String(base64Str), aes.Key, aes.IV);
            }
        }
        static byte[] EncryptString(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }
        static string DecryptString(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            string plaintext = null;
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
3.After encrypt string will be 
/Registros/Edit/ZF%252F4Q5oa2zXyzUtDSH33sA%253D%253D
  4. You may got IIS 404.11 Error. go to IIS Admin  > MIME > Check Double escape On.
  5. By the way ! AES Dncrypt with url may got error. becuase `+` and `space` must be replaced.you may check this answer [https://stackoverflow.com/a/10025926/7016640][1]
  [1]: https://stackoverflow.com/a/10025926/7016640
6 days ago. hope this help !
