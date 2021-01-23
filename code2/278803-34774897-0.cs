	public partial class Login : System.Web.UI.Page
	{
		protected override void OnInit(EventArgs e) // i added this method.
		{
			Load += new EventHandler(Page_Load);
			base.OnInit(e);
		}
		protected void Page_Load(object sender, EventArgs e)
		{ // code for the Page Load event here
		}
	}
