    namespace System.Web.UI.WebControls
    {
        public class Login : CompositeControl
        {
            // other code omitted
            protected virtual void OnAuthenticate(AuthenticateEventArgs e)
            {
                AuthenticateEventHandler handler = this.Authenticate;
        
                if (handler != null)
                    handler(this, e);
                else
                    this.AuthenticateUsingMembershipProvider(e);
            }
            private void AuthenticateUsingMembershipProvider(AuthenticateEventArgs e)
            {
                var provider = LoginUtil.GetProvider(this.MembershipProvider);
                e.Authenticated = provider.ValidateUser(
                        this.UserNameInternal, this.PasswordInternal);
            }
        }
    }
 
