    [DataContract]
    public class FooResult {
        [DataMember]
        public string Error {get;set;}
        [DataMember]
        public SomeType Result {get;set;}
    }
