        public static IEnumerable<string> ReadAsLines(this string text)
        {
            TextReader reader = new StringReader(text);
            while(reader.Peek() >= 0)
            {
                yield return reader.ReadLine();
            }
        }
