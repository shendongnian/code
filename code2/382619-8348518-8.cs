    [DataContract(Name = "GenericType")]
    [KnownType(typeof (MyType))]
    public class GenericType<T>
    {
        [DataMember]
        public List<T> Data { get; set; }
    }
    public class MyType
    {
        public string Stuff { get; set; }
    }
