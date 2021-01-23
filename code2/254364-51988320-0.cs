    [AttributeUsage(AttributeTargets.Field,AllowMultiple =false)]
    public class GPUShaderAttribute: Attribute
    {
        public GPUShaderAttribute(string value)
        {
            Value = value;
        }
        public string Value { get; internal set; }
    }
