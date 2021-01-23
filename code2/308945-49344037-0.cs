        private string RemoveExcessiveWhitespace(string value)
        {
            if (value == null) { return null; }
            var builder = new StringBuilder();
            var ignoreWhitespace = false;
            foreach (var c in value)
            {
                if (!ignoreWhitespace || c != ' ')
                {
                    builder.Append(c);
                }
                ignoreWhitespace = c == ' ';
            }
            return builder.ToString();
        }
