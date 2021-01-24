    public partial class StatusWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String strStatus = (String)Session["key1"];
            lblStatus.Text = strStatus;
        }
    }
