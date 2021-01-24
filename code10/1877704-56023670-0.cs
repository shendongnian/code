    {
        public string name { get; set; }
        public string dataType { get; set; }
        public string referenceType { get; set; }
        public bool? isArray { get; set; }
    }
    public class Type
    {
        public string name { get; set; }
        public List<Field> fields { get; set; }
        public string parentType { get; set; }
    }
    public class RootObject
    {
        public List<Type> types { get; set; }
    }
