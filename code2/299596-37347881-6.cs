    public class RemoveWhitespace
    {
        public static string RemoveStringReader(string input)
        {
            var s = new StringBuilder(input.Length);// (input.Length);
            using (var reader = new StringReader(input))
            {
                int i = 0;
                char c;
                for (; i < input.Length; i++)
                {
                    c = (char)reader.Read();
                    if (!char.IsWhiteSpace(c))
                    {
                        s.Append(c);
                    }
                }
            }
    
            return s.ToString();
        }
    
        public static string RemoveLinqNativeCharIsWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    
        public static string RemoveLinq(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    
        public static string RemoveRegex(string input)
        {
            return Regex.Replace(input, @"\s+", "");
        }
    
        private static Regex compiled = new Regex(@"\s+", RegexOptions.Compiled);
        public static string RemoveRegexCompiled(string input)
        {
            return compiled.Replace(input, "");
        }
    
        public static string RemoveForLoop(string input)
        {
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(input[i]))
                {
                    input = input.Remove(i, 1);
                }
            }
    
            return input;
        }
    
        public static string RemoveInPlaceCharArray(string input)
        {
            var len = input.Length;
            var src = input.ToCharArray();
            int dstIdx = 0;
            for (int i = 0; i < len; i++)
            {
                var ch = src[i];
                switch (ch)
                {
                    case '\u0020':
                    case '\u00A0':
                    case '\u1680':
                    case '\u2000':
                    case '\u2001':
                    case '\u2002':
                    case '\u2003':
                    case '\u2004':
                    case '\u2005':
                    case '\u2006':
                    case '\u2007':
                    case '\u2008':
                    case '\u2009':
                    case '\u200A':
                    case '\u202F':
                    case '\u205F':
                    case '\u3000':
                    case '\u2028':
                    case '\u2029':
                    case '\u0009':
                    case '\u000A':
                    case '\u000B':
                    case '\u000C':
                    case '\u000D':
                    case '\u0085':
                        continue;
                    default:
                        src[dstIdx++] = ch;
                        break;
                }
            }
    
            return new string(src, 0, dstIdx);
        }
    }
