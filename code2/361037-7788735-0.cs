    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            TestUserControl uc = (TestUserControl)Page.LoadControl("~/UserControls/TestUserControl.ascx");
            Panel1.Controls.Add(uc);
            uc.Fill();
        }
    }
