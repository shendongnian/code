    public sealed class NamedItem
    {
        private readonly string name;
        private readonly object value;
    
        public NamedItem (string name, object value)
        {
            this.name = name;
            this.value = value;
        }
    
        public string Name { get { return name; } }
        public object Value { get { return value; } }
    
        public override string ToString ()
        {
            return name;
        }
    }
