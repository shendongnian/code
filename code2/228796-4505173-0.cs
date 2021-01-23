    using System.Text.RegularExpressions;
    
    namespace Extensions
    {
        static class SystemStringExtensions
        {
            public static string RemoveNewlines(this string inputString)
            {
                // replace newline characters with spaces
                return Regex.Replace(inputString, "\\n+", " ");
            }
        }
    }
