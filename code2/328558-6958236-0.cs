    [DataContract]
    public class MyClass
    {
        [DataMember(Order=1)] // <==== this provides the 1 as the key
        public int SomeProp {get; set;}
    
        // see below re callback
    }
