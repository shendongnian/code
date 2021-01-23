    [AttributeUsage(AttributeTargets.Field)]
    public class DBDataTypeAttribute : System.Attribute
    {
        private readonly string _fieldType;
        private readonly bool _allowNulls;
        public DBDataTypeAttribute(string fieldType, bool allowNulls)
        {
            _fieldType = fieldType;
            _allowNulls = allowNulls;
        }
        public string FieldType 
        {
            get { return _fieldType; } 
        } 
        
        public bool AllowNulls
        { 
            get { return _allowNulls; }
        } 
    }
