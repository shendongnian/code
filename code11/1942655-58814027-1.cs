       public static string DecryptString(string str)
        {
            return Decrypt(str, "!#$a54?3");
        }
    
        private static string Decrypt(string stringToDecrypt, string sEncryptionKey)
        {
            
            byte[] key = { };
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 }; //try {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
            byte[] inputByteArray = new byte[stringToDecrypt.Length];
            try
            {
                key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt.Replace(" ", "+"));
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
    
            }
            catch (System.Exception ex)
            {
                throw ex;
                
            }
    
    
        }
