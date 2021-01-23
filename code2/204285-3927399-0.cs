    // match the properties to the xml dynamically using this attribute...
    [AttributeUsage(AttributeTargets.Property)]
    public class DBSPropAttribute : Attribute
    {
        public string MappingField { get; set; }
        public DBSPropAttribute(string fieldName)
        {
            MappingField = fieldName;
        }
    }
