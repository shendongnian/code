    public class MyMembershipUser : MembershipUser
    {
        public MyMembershipUser()
        {
        }
        public MyMembershipUser(string username)
            : base("MyMembershipProvider", username, null, "", "", "", true, true, DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today)
        {
        }
        public override bool ChangePassword(string oldPassword, string newPassword)        
        {
            //Do something
        }
    }
