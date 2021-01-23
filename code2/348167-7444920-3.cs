    [DataContract]
    [KnownType(typeof(ChildModel))]
    public class BaseModel
    {
        [DataMember]
        public string Id { get; set; }
    }
