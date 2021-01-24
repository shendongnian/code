    public class ObjectA
    {
        public ObjectB ObjectB { get; set; }
        public bool IsValid()
        {
            if (ObjectB == null) return false;
            return ObjectB.IsValid();
        }
    }
    public class ObjectB
    {
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Attribute1) 
            && !string.IsNullOrWhiteSpace(Attribute2) ;
            && !string.IsNullOrWhiteSpace(Attribute3)
        }
    }
