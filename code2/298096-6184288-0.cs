    using System;
    using System.Security.Cryptography;
    using System.Text;
    public class CryptoUtils
    {
        public static string CalculateMD5Hash(string strInput)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(strInput);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        } 
    }
    
    class Program
    {
        static void Main()
        {
            var input = "some input";
            var md5 = CryptoUtils.CalculateMD5Hash(input);
            Console.WriteLine(md5);
        }
    }
