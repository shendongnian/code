    public class UserInfo
    {
       public String SessionTokenIDV1 { get; set; }
    
    }
    
    
    public class Example
    {
      // Private vars
      private UserInfo _userInfo = new UserInfo();
    
      public bool SessionValidV1
      {
        get { return ((_userInfo.SessionTokenIDV1 != null) && (_userInfo.SessionTokenIDV1.Length > 0)); }
        private set { _userInfo.SessionTokenIDV1 = value; }
      }
    }
