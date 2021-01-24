    using System;
    using System.Text;
    using System.Security.Cryptography;
    				
    public class Program
    {
    	public static void Main()
    	{
    		 string source = "Hello World!";
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, source);
                    Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");
                }
    	}
          static string GetMd5Hash(MD5 md5Hash, string input)
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
    }
