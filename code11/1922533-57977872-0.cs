    public partial class Default : System.Web.UI.Page
    {
        private SiteMaster MyMaster => ((SiteMaster) Master);
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = MyMaster.UserName;
        }
    }
