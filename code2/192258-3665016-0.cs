    public class MAP
    {
        public readonly string Name;
        private string code;
        
        public string Code { get { return code; } }
        public string Display { get { return ToString(); } }
        public MAP(string Name, string Code)
        {
            this.Name = Name;
            this.code = Code;
        }
        public override string ToString()
        {
            return String.Format("{0}: {1}", Name, Code);
        }
    }
