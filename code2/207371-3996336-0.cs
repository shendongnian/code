    using System.Text;
    using System;
    
    class EncodingConverter
    {
        static string ConvertEncoding(string input, 
            Encoding srcEncoding, 
            Encoding targetEncoding)
        {
            byte[] buffer = srcEncoding.GetBytes(input);
            return targetEncoding.GetString(buffer);
        }
    
        static void Main(string[] args)
        {
            string input = args[0];
            string converted = ConvertEncoding(input, 
                Encoding.GetEncoding("windows-1250"), 
                Encoding.GetEncoding("iso-8859-2"));
            Console.WriteLine(converted);
        }
    }
 
