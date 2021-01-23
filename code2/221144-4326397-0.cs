    public class CustomMembershipProvider: MembershipProvider
    {
        private providerName = null;
        ...
    
        public override void Initialize(string name, NameValueCollection config)
        {
            providerName = name; // The friendly name of the provider
            ...
        }
    
        public override MembershipUser TestCreateUser(string username, bool userIsOnline)
        {
            CustomMembershipUser membershipUser = new CustomMembershipUser(providerName,
                  username,
                  Guid.Parse(userID.ToString()),
                  email,
                  passwordQuestion,
                  comment,
                  isApproved,
                  isLockedOut,
                  creationDate,
                  lastLoginDate,
                  lastActivityDate,
                  lastPasswordChangedDate,
                  lastLockedOutDate, "ss");
            ...
        }
    }
