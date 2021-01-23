    using System;
    using System.Security.Cryptography;
    using System.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            string DataForEncrypting = "this is a test";
            
            string key = string.Empty;
            string iv = string.Empty;
            
            using (RijndaelManaged rmt = new RijndaelManaged())
            {
                rmt.KeySize = 256;
                rmt.BlockSize = 128;
                rmt.Mode = CipherMode.CBC;
                rmt.Padding = PaddingMode.ISO10126;
                rmt.GenerateKey();
                rmt.GenerateIV();
                key = Convert.ToBase64String(rmt.Key);
                iv = Convert.ToBase64String(rmt.IV);
            }
            
            string encryptedData = _encrypt(DataForEncrypting, key, iv);
            string unencryptedData = _decrypt(key, iv, encryptedData);
            
            Console.WriteLine(unencryptedData);
            Console.WriteLine(encryptedData);
            Console.ReadKey();
        }
        
        private static string _encrypt(string value, string key, string initVector)
        {
            using (RijndaelManaged rmt = new RijndaelManaged())
            {
                rmt.KeySize = 256;
                rmt.BlockSize = 128;
                rmt.Mode = CipherMode.CBC;
                rmt.Padding = PaddingMode.ISO10126;
                byte[] plainText = Encoding.UTF8.GetBytes(value);
                byte[] cipherText = rmt.CreateEncryptor(Convert.FromBase64String(key),
                                                        Convert.FromBase64String(initVector))
                                       .TransformFinalBlock(plainText, 0, plainText.Length);
                return Convert.ToBase64String(cipherText);
            }
        }
        
        private static string _decrypt(string key, string initVector, string value)
        {
            using (RijndaelManaged rmt = new RijndaelManaged())
            {
                rmt.KeySize = 256;
                rmt.BlockSize = 128;
                rmt.Mode = CipherMode.CBC;
                rmt.Padding = PaddingMode.ISO10126;
                byte[] cipherText = Convert.FromBase64String(value);
                byte[] plainText = rmt.CreateDecryptor(Convert.FromBase64String(key),
                                                       Convert.FromBase64String(initVector))
                                      .TransformFinalBlock(cipherText, 0, cipherText.Length);
                return Encoding.UTF8.GetString(plainText);
            }
        }
    }
