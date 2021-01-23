    [DataContract]
    public class User
    {
      public  int Id { get; set; }
      [DataMember]
      public string Name { get; set; }
      [DataMember]
      public string Code { get; set; }
    }
