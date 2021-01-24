    public static class MorseCodeConverter
    {
        private static readonly Dictionary<char, string> Codes 
            = CreateMorseCodeDictionary();
        public static string Convert(string input)
        {
            var lowerCase = input.ToLower();
            var result = new StringBuilder();
            foreach (var character in input)
            {
                if (Codes.ContainsKey(character))
                    result.Append(Codes[character]);
            }
            return result.ToString();
        }
        static Dictionary<char, string> CreateMorseCodeDictionary()
        {
            var result = new Dictionary<char, string>();
            result.Add('a', ". _ - ");
            result.Add('b', "_ . . . - ");
            // add all the rest
            return result;
        }
    }
