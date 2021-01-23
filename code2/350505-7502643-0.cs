    [DataContract]
    [KnownType(typeof(Medium))]
    [KnownType(typeof(Small))]
    public class Manager
    {
      [DataMember]
      public BigBase[] enemies;
    }
