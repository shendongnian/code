    public partial class Repeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<URL> urls = new List<URL>()
                {
                    new URL(){ Link = "http://www.google.com", Title = "Google"},
                    new URL(){ Link = "http://www.yahoo.com", Title = "Yahoo"}
                };
                rptPageNav.DataSource = urls;
                rptPageNav.DataBind();
            }
        }
    }
    
    public class URL
    {
        public string Link { get; set; }
        public string Title { get; set; }
    }
