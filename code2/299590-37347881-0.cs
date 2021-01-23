    public class RemoveWhitespace
    {
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
            for (int i = input.Length -1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(input[i]))
                {
                    input = input.Remove(i, 1);
                }
            }
    
            return input;
        }
    }
