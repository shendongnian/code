    namespace MyCompany.Applications.MyApplication.Presentation.Web
    {
        public partial class MyPage : System.Web.UI.Page
        {
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                }
            }
    
            private void LogoutUser()
            {
                Helpers.SessionHelpers.LogoutUser(this.Context);
            }
    }
