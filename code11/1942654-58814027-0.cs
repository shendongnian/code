    public static string EncryptString(string str)
            {
                return Encrypt(str, "!#$a54?3");
            }
        
            private static string Encrypt(string stringToEncrypt, string sEncryptionKey)
            {
                
                byte[] key = { };
                byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
                byte[] inputByteArray; //Convert.ToByte(stringToEncrypt.Length)
                try
                {
                    key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
