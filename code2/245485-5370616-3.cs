    using System;
    namespace TestWebApp1
    {
        public partial class SiteLayout : System.Web.UI.MasterPage
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                lblTest.Text = "Modified from master page's Page_Load method.";
            }
        }
    }
