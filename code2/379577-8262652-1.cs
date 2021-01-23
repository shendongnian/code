    // Global.asax
    void Application_BeginRequest(object sender, EventArgs e)
    {
        HttpContext.Current.Items["hello"] = DateTime.Now;
    }
    // Default.aspx
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = HttpContext.Current.Items["hello"].ToString();
        }
    }
