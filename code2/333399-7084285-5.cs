    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class WriteableAttribute : Attribute
    {
        public int Order { get; set; }
    }
