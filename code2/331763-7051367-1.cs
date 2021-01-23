    public class MyPrincipal : IMyPrincipal
    {
        private MembershipUser _user;
        public MyPrincipal()
        {
            this._user = Membership.GetUser();
            var userName = this._user != null ? this._user.UserName : String.Empty;
            this.Identity = new GenericIdentity(userName);
        }
        public Guid UserId
        {
            get 
            { 
                return this._user != null ? (Guid) this._user.ProviderUserKey : 
                                            default(Guid);
            }
        }
        public string EmailAddress
        {
            get 
            { 
                return this._user != null ? this._user.Email : null;
            }
        }
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }
    }
