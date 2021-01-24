    // allow mutliple attributes specified in data annotations
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    // model for custom attribute class
    public class CustomAttribute : Attribute
    {
        public string ParameterName { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public CustomAttribute(string parameterName, string value, string description = null)
        {
            this.ParameterName = parameterName;
            this.Value = value;
            this.Description = description;
        }
    }
