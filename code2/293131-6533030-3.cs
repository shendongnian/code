    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using System.IO;
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		public static string Encode(string input, byte[] key)
    		{
    			HMACSHA1 myhmacsha1 = new HMACSHA1(key);
    			byte[] byteArray = Encoding.ASCII.GetBytes(input);
    			MemoryStream stream = new MemoryStream(byteArray);
    			return myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}",e), s => s );
    		}
    
    
    		static void Main(string[] args)
    		{
    			byte[] key = Encoding.ASCII.GetBytes("abcdefghijklmnopqrstuvwxyz");
    			string input = "";
    			foreach (string s in new string[] { "Marry", " had", " a", " little", " lamb" })
    			{
    				input += s;
    				System.Console.WriteLine( Encode(input, key) );
    			}
    			return;
    		}
    	}
    }
