    public static class StringExtensions
    {
        private static readonly char[] TrimNewLineChars = Environment.NewLine.ToCharArray();
    
        public static string RemoveEmptyLines(this string str)
        {
            if (str == null)
            {
                return null;
            }
    
            var lines = str.Split(TrimNewLineChars, StringSplitOptions.RemoveEmptyEntries);
    
            var stringBuilder = new StringBuilder(str.Length);
    
            foreach (var line in lines)
            {
                stringBuilder.AppendLine(line);
            }
    
            return stringBuilder.ToString().TrimEnd(TrimNewLineChars);
        }
    }
