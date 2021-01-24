        public static string test(string value)
        {
            value = value ?? string.Empty;
            int half = value.Length % 2 == 0 ? (value.Length / 2) - 1: (value.Length / 2);
            Regex r = new Regex("(?<=^.{"+ half + "})[a-zA-Z]{1,2}(?=.{"+ half + "}$)");
            var match = r.Match(value);
            if (match != null)
            {
                var result = r.Replace(value, match.ToString().ToUpper());
                return result;
            }
            return value;
        }
