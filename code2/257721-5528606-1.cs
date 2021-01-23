    public class UserMembershipSQL : SqlMembershipProvider
    {
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            // do your stuff, don't call base
        }
    
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            // do your stuff, don't call base
        }
    }
