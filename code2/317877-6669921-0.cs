    // Level0 Master Page
    public partial class Root : System.Web.UI.MasterPage
    {
        public void AddError(string strWhen, string strMessage)
        {
            lblAlert.Text += "<p>" + "Une erreur s'est produite " + strWhen + "<br/>'" + strMessage + "'</p>";
        }
    }
    
    // Level1 Master Page
    public partial class OneColumn : System.Web.UI.MasterPage
    {
        public void AddError(string strWhen, string strMessage)
        {
            ((Root)Master).AddError(strWhen, strMessage);
        }
    }
    
    // Content Page
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((OneColumn)Master).AddError("test", "test");
        }
    }
