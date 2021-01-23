    [MetadataType(typeof(MyEntities.Customer))]
    [DataContract(Name = "entry")]
    public partial Customer
    {
      [DataMember(Name = "id")]
      public string Id { get; set; }
      [DataMember(Name = "title")]
      public string Title { get; set; }
    }
