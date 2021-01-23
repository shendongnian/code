    using System;
    using System.Text;
    
    namespace encodingtest
    {
    	class Program
    	{
    		public static void Main(string[] args)
    		{
    			string encoded = Encode("Hello World!", 43);
    			Console.WriteLine(encoded);
    			Console.WriteLine(Decode(encoded));
    			
    			Console.Write("Press any key to continue . . . ");
    			Console.ReadKey(true);
    		}
    		
    		static public string Encode(string source, int length)
    		{
    			byte[] bytes = Encoding.UTF8.GetBytes(source);
    
    			StringBuilder buffer = new StringBuilder(length);
    			buffer.Append(System.Convert.ToBase64String(bytes));
    			while (buffer.Length < length) {
    				buffer.Append('=');
    			}
    			return buffer.ToString();
    		}
    		
    		static public string Decode(string encoded) {
    			int index = encoded.IndexOf('=');
    			if (index >0) {
    				encoded = encoded.Substring(0, ((index + 3) / 4) * 4);
    			}
    			byte[] bytes = System.Convert.FromBase64String(encoded);
    			return System.Text.Encoding.UTF8.GetString(bytes);
    		}
    	}
    }
