     public sealed class MyMembershipProvider : MembershipProvider {
        //... much more here 
        //example method:
        public override bool ChangePassword(string username, string oldPwd, string newPwd)
        {
            //access simpleDb here
        }
     }
