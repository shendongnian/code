    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
    public class XMLAttributeProperty : Attribute
    {
        public XMLAttributeProperty(string name, string value)
        {
            this.Name = name;
            Value = value;
        }
        public string Name;
        public string Value;
    }
