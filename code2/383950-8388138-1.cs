    public static class StreamReaderExtensions
    {
        public static string ReadLine(this StreamReader self, int bufferSize)
        {
            string line = String.Empty;
            char[] buffer = new char[bufferSize];
            while (true)
            {
                foreach (var i in Enumerable.Range(0, bufferSize))
                {
                    if (self.ReadBlock(buffer, i, 1) != 1
                        || buffer[i] == '\r'
                        || buffer[i] == '\n')
                    {
                        line += new String(buffer, 0, i);
                        return line;
                    }
                }
                line += new String(buffer);
            }
        }
    }
