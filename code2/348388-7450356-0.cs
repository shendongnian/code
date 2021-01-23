    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace Test
    {
    	public class SO7449615
    	{
    		public static string encrypt_php_data(string stringToEncrypt, string key) {
    			ASCIIEncoding asciiEncoding = new ASCIIEncoding();
    			byte[] stringToEncryptBytes = asciiEncoding.GetBytes(stringToEncrypt);
    			byte[] keyBytes = asciiEncoding.GetBytes(key);
    			
    			byte[] retBytes = new byte[stringToEncryptBytes.Length];
    			for (int i = 0; i < stringToEncryptBytes.Length; ++i) {
    				byte keyByte = keyBytes[(i + keyBytes.Length - 1) % keyBytes.Length];
    				retBytes[i] = (byte)(stringToEncryptBytes[i] + keyByte);
    				//Console.Write(' ');
    				//Console.Write(retBytes[i]);
    			}
    			//Console.WriteLine();
    			return asciiEncoding.GetString(retBytes);
    		}
    	
    		public static void Main(string[] args)
    		{
    			string stringToEncrypt = "test";
    			string key = "somekey";
    			Console.WriteLine(encrypt_php_data(stringToEncrypt, key));
    		}
    	}
    }
