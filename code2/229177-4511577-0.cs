    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ExampleAttribute : Attribute
    {
        public ExampleAttribute(string attributeValue)
        {
            this.AttributeValue = attributeValue;
        }
    
        public string AttributeValue
        {
            get;
            set;
        }
    }
