    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IgnoreSerializationAttribute : Attribute
    {
        public bool Ignore { get; private set; }
        public IgnoreSerializationAttribute(bool ignore)
        {
            Ignore = ignore;
        }
    }
