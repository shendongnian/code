    class StreamParser
    {
        private readonly TextReader m_reader;
        public StreamParser(string s)
            : this(new StringReader(s))
        {}
        public StreamParser(TextReader reader)
        {
            m_reader = reader;
        }
        public string ReadString()
        {
            var result = new StringBuilder();
            int c = m_reader.Read();
            while (c != -1 && (char)c != ' ')
            {
                result.Append((char)c);
                c = m_reader.Read();
            }
            if (result.Length > 0)
                return result.ToString();
            return null;
        }
        public int ReadInt32()
        {
            return int.Parse(ReadString());
        }
    }
