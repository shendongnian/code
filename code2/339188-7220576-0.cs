    public class CustomUser : MembershipUser
    {
        public CustomUser(string providername,
                        User userAccount) :
            base(providername,
                            userAccount.UserName,
                            userAccount.Id,
                            userAccount.Email,
                            passwordQuestion,
                            string.Empty,
                            true,
                            false,
                            userAccount.CreationDate,
                            userAccount.LastLoginDate,
                            userAccount.LastActivityDate,
                            new DateTime(),
                            new DateTime())
        {
            UserAccount = userAccount;
        }
        public User UserAccount { get; private set; }
    }
