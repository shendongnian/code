    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Security;
    namespace WebProject.Core.Utilities
    {
        public class CustomParameter : Parameter
        {
            protected override object Evaluate(HttpContext context, Control control)
            {
                MembershipUser currentUser = Membership.GetUser();
                return currentUser.ProviderUserKey;
            }
        }
    }
