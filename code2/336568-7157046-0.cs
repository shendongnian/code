    public interface IBase {}
    
    [DataContract]
    [KnownType(typeof(Derived))]
    public class Base : IBase
    {
        [DataMember]
        public Derived Child{get;set;}
    }
    
    [DataContract]
    public class Derived : Base
    {
        [DataMember]
        public Base Parent {get;set;}
    }
