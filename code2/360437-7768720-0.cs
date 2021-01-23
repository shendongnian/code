    public abstract class MyBasePage : System.Web.UI.Page
    {
        protected Display_Type PageSettings { get; private set; };
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["Is_Admin"])
            {
                PageSettings = new AdminPage();
            }
            else
            {
                PageSettings = new UserPage();
            }
        }
    }
    public partial class MyPage : MyBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ...
    
            string backgroundColor = PageSettings.backgroundColor;
            // ... Do stuff with background color
        }
    }
