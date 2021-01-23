    using System;
    
    namespace WebApplication1
    {
        public partial class SiteMaster : System.Web.UI.MasterPage
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                this.environmentLabel.Text = "environment";
                this.environmentLabel.BackColor = System.Drawing.Color.Red;
            }
        }
    }
