    public class UserInformation
    {
      public string User { get; set; }
      public string Password { get; set; }
    }
    
    [DataContract]
    public class Request
    {
      [DataMember]
      public UserInformation User { get; set; }
      [DataMember]
      public MyRequest RequestBody { get; set; }
    }
