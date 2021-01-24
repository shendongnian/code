    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^(\b[0-9a-f]{8}\b-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-\b[0-9a-f]{12}\b)\s*\|\s*(.*?)\s*$";
            string substitution = @"http://my-server/media/guid/\1?v=$2";
            string input = @"35afe06d-8393-4559-b6d7-74d35ce131d8|Master
    35afe06d-8393-4559-b6d7-74d35ce131d8|  Master  ";
            RegexOptions options = RegexOptions.Multiline;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
        }
    }
