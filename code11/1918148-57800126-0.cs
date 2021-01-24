    [DataContract]
    public class Details
    {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public virtual string id { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public virtual string name { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public virtual string creator { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public virtual string format { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public virtual string creationTime { get; set; }
    }
