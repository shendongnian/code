    public partial class SiteMaster : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e) {}
		public void SetLabelText(string text) {
			this.Label1.Text = text;
		}
	}
