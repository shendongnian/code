    public partial class NoRenderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }
    
        public override void VerifyRenderingInServerForm(Control control)
        {
            //Allows for printing
        }
    
        public override bool EnableEventValidation
        {
            get { return false; }
            set { /*Do nothing*/ }
        }
    }
