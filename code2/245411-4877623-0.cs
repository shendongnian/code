    class Parser
    {
        public abstract object Parse(string text);
    }
    
    class Int32Parser
    {
        public int Parse(Parser parser, string text)
        {
            return parser.Parse(text);
        }
    }
