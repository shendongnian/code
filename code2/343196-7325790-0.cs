    public partial class PageB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           string info = PageA.GetStringInfo();        
        }
    }
