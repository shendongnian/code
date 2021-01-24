    [DataContract]
    public class DetailsVariantA : Details
    {
        [DataMember(EmitDefaultValue = false, Order = 5)]
        public override string id { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 4)]
        public override string name { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public override string creator { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public override string format { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public override string creationTime { get; set; }
    }
