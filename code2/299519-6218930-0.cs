    // NOTE: You can use POCO DataContract serialization for this type.
    [DataContract]
    public class Pair
    {
        [DataMember]
         public string Key { get; set; }
    
        [DataMember]
         public string Value { get; set; }
    }
