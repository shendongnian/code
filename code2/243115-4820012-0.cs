    using System;
    using System.Text;
    using System.Security.Cryptography;
    
    namespace CSharpSandbox
    {
        class Program
        {
            public static string HashPassword(string input)
            {
                var sha1 = SHA1Managed.Create();
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] outputBytes = sha1.ComputeHash(inputBytes);
                return BitConverter.ToString(outputBytes).Replace("-", "").ToLower();
            }
    
            public static void Main(string[] args)
            {
                string output = HashPassword("The quick brown fox jumps over the lazy dog");
            }
        }
    }
