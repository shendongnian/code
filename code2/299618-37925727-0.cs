        public static string RemoveWhitespace(this string input)
        {
            if (input == null)
                return null;
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
