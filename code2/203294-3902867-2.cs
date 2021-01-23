    [DataContract]
    public class MyClass {
        [DataMember]
        public int IntMember { get; set; }
        [DataMember]
        public string StringMember { get; set; }
        [DataMember]
        public MyType[] AllTypes { get; set;}
    }
    [DataContract]
    public class MyType {
        [DataMember]
        public int num { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int state { get; set;}
    }
