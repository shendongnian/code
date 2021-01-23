    public partial class MyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["Is_Admin"])
            {
                body.Attributes["class"] = "AdminPage";
            }
            else
            {
                body.Attributes["class"] = "UserPage";
            }
        }
    }
