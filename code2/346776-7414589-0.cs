    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    var currentRequest = HttpContext.Current.Handler;
                }
            }
        }
    }
