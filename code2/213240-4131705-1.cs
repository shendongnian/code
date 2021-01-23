    [DataContract]
    [KnownType(typeof(List<Item>))]
    public class MyClass
    {
        ... 
        [DataMember]
        public virtual IList<Item> Items {get;set;}
        ...
    }
