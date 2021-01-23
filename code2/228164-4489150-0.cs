        public static IEnumerable<string> SplitOnCapitals(string text)
        {
            Regex regex = new Regex(@"\p{Lu}\p{Ll}*");
            foreach (Match match in regex.Matches(text))
            {
                yield return match.Value;    
            }
        }
