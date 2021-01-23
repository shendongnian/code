       public partial class WebUserControl1 : System.Web.UI.UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
            public void SetText(string theText)
            {
                this.Label1.Text = theText;
            }
        }
