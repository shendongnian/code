    [KnownType(typeof(ExpandoObject))]
    [DataContract]
    public class Root
    {
        [DataMember]
        public string Name { get; set; }
            
        [DataMember]
        public dynamic DynamicValues { get; set; }
    }
