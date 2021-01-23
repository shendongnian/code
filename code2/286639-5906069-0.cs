    public class User
    {
      public Guid UserId{get;set;}
      public string UserName{get;set;}
      public String UserAddress{get;set;}
      public IList<User> Friends{get;set;}
      // other user properties
    }
