    [DataContract]
    [KnownType(typeof(List))]
    public class MyClass
    {
        ... 
        [DataMember]
        public virtual IList<Item> Items {get;set;}
        ...
    }
