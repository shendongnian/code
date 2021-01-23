    public class MyMagicCloudMembershipProvider : System.Web.Security.MembershipProvider 
    {
      public override MembershipUser GetUser(String username, boolean isOnline)
      {
        return ToTheCloud.RetrieveUserInfo(username);
      }
    
      public override bool ValidateUser(string username, string password)
      {
        var user = GetUser(username);
    
        if(user.IsLocked && user.LastLockoutDate > DateTime.Now.AddMinutes(-30))
           UnlockUser(username);
    
        return ToTheCloud.WithWindowsSeven(user, password);
      }
    }
