    public class MasterClass
    {
        public TypesClass[] Property1 { get; set; }
    }
    
    public class TypesClass
    {
        public string type { get; set; }
        public Type[] types { get; set; }
    }
    
    public class Type
    {
        public string type { get; set; }
        public Types[] types { get; set; }
    }
    
    public class Types
    {
        public string type { get; set; }
        public int count { get; set; }
    }
