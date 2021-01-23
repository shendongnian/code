    class Port
    {
        public PortType Type 
        { 
            get;
            set; 
        }
        public IEnumerable<Rule> Rules 
        { 
            get; 
            set;
        }
        public Port(PortType type, IEnumerable<Rule> rules)
        {
            this.Type = type;
            this.Rules = rules ?? Enumerable.Empty<Rule>();
        }
    }
    enum PortType
    {
        AND,
        OR
    }
