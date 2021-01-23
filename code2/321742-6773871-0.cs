    namespace WebApplication2
    {
        public partial class WebUserControl1 : System.Web.UI.UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            public string HiddenFildProperty
            {
                get { return hdnID.Value; }
                set { hdnID.Value = value; }
            }
        }
    }
