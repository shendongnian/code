    [DataContract]
    class Company {
      [DataMember]
      public string Name { get; set; }
      [DataMember]
      public IAddress Address { get; set; }
    }
