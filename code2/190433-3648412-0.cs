    [CollectionDataContract(IsReference = true, ItemName = "Param",
                            KeyName = "Name", ValueName = "Data")]
    public class DataTree : Dictionary<string, DataTreeEntry>
    {
    }
    [DataContract]
    public class DataTreeEntry
    {
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public DataTree Children { get; set; }
    }
