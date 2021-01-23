    class Rule : IEquatable<Rule>
    {
        public string Value 
        { 
            get; 
            set;
        }
        public string Name 
        { 
            get;
            set; 
        }
        public Rule(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public bool Equals(Rule other)
        {
            return this.Name == other.Name;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
