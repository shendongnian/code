    [AttributeUsage(AttributeTargets.Field)]
    public class DBDataTypeAttribute : System.Attribute
    {
        public string FieldType { get; set; }
        public bool AllowNulls { get; set; }
    }
