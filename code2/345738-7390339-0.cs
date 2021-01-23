    public class StringValueAttribute : Attribute {
        public string StringValue { get; protected set; }
        public StringValueAttribute(string value) {
            this.StringValue = value;
        }
    }
