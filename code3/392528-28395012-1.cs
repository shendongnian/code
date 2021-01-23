	public partial class _Default : System.Web.UI.Page 
	{
		private readonly RequestContext RequestContext
		{
			get { return (RequestContext)HttpContext.Current.Items("requestContext"); }
		}
		
		protected void Page_Load(object sender, EventArgs e)
		{
			RequestContext.HttpContext.Response.Redirect("~/SaveUser");
		}
	}
