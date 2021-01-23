    public static class StreamReaderExtensions
    {
        public static string ReadLineSingleBreak(this StreamReader self)
        {
            StringBuilder currentLine = new StringBuilder();
            int i;
            char c;
            while ((i = self.Read()) >= 0)
            {
                c = (char)i;
                if (c == '\r'
                    || c == '\n')
                {
                    break;
                }
                currentLine.Append(c);
            }
            return currentLine.ToString();
        }
    }
