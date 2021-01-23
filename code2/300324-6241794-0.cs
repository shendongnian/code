    public class MainController : Controller
    {
        public MembershipUser _user = null;
        public MembershipUser User {
            if(_user == null) _user = Membership.GetUser(model.Username);
            return _user;
        }
        public GUID UserGuid {
            get { return (Guid)User.ProviderUserKey;; }
        }
    }
