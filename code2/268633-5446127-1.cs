    public partial class Default : System.Web.UI.Page
    {
        MembershipUser currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = Membership.GetUser();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (null != currentUser)
            {
                Guid currentUserID = currentUser.ProviderUserKey;
                // database code here
            }
        }
    }
