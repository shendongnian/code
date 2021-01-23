    class Parser
    {
        private readonly Queue<string> m_parts;
        public Parser(string s)
        {
            m_parts = new Queue<string>(s.Split(' '));
        }
        public string ReadString()
        {
            return m_parts.Dequeue();
        }
        public int ReadInt32()
        {
            return int.Parse(ReadString());
        }
    }
