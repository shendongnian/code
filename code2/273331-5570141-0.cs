    public static class Extensions
    {
        static readonly char[] _whiteSpaceCharacters;
    
        static Extensions()
        {
            var r = new List<char>();
            for (char c = char.MinValue; c < char.MaxValue; c++)
                if (char.IsWhiteSpace(c))
                    r.Add(c);
            _whiteSpaceCharacters = r.ToArray();
        }
    
        public static string LeftJustify(this string value)
        {
            return value.LeftJustify(4);
        }
    
        public static string LeftJustify(this string value, int length)
        {
            var sb = new StringBuilder();
            using (var sr = new StringReader(value))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(
                        line
                        .TrimStart(_whiteSpaceCharacters)
                        .PadLeft(length, ' ')
                    );
                }
            }
            return sb.ToString();
        }
    }
