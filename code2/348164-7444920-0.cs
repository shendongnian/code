    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public string Id { get; set; }
    }
    [DataContract]
    public class ChildModel: BaseModel
    {
        [DataMember]
        public string Foo { get; set; }
    }
