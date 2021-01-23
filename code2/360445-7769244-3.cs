    public partial class MyPage : System.Web.UI.Page
    {
        Color backgroundColor = null;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["Is_Admin"])
            {
                backgroundColor = Properties.PagesStyle.Default.AdminPage_BackgroundColor;
            }
            else
            {
                backgroundColor = Properties.PagesStyle.Default.UserPage_BackgroundColor;
            }
    
            // ... Do stuff with background color
        }
    }
