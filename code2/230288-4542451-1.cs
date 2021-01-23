    public class MyMagicCloudMembershipProvider : System.Web.Security.MembershipProvider 
    {    
      public override bool ValidateUser(string username, string password)
      {
        return ToTheCloud.WithWindowsSeven(user, password);
      }
    }
