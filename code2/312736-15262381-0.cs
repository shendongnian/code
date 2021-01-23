    DataContract(IsReference = true)]
    public class SampleObject
    {
      [DataMember]
      public long ID { get; private set; }
    
      [DataMember]
      public AnotherObjectCollection Objects { get; set; }
    }
