    public enum FieldDataTypes 
    {
        [FormTypeMetadata(typeof(string))]
        PlainText = 0, 
        [FormTypeMetadata(typeof(int))]
        Number = 1,
        [FormTypeMetadata(typeof(decimal))]
        Currency = 2
    }
    public class FormTypeMetadataAttribute : Attribute
    {
        private readonly Type _baseType = typeof(object);
        public FormTypeMetadataAttribute(Type baseType)
        {
            if (baseType == null) throw new ArgumentNullException("baseType");
            _baseType = baseType;
        }
        public Type BaseType { get { return _baseType; } }
    }
    // your 'FieldData' implementation would look like this...
    public class FieldData
    {
        public FieldDataTypes FieldType { get; set; }
        public object Value { get; set; }
    }
