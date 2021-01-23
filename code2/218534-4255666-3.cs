    public class SqlMembershipProvider : System.Web.Security.SqlMembershipProvider
    {
        public override bool ValidateUser(string userName, string password)
        {
            // do your logic
            
            // use built-in properties, parsed by base class for you, such as:
            if (password.Length < this.MinRequiredPasswordLength)
            {
            }
            //if ok, then:
            base.ValidateUser(userName, password);
        }
        public override MembershipUser CreateUser(string userName, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            // do your logic
            //if ok, then:
            base.CreateUser(...);
        }
