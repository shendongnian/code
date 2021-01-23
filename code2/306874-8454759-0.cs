    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //
        }
    
        // the property which I would like to access from user control  
        public String MyName
        {
            get
            {
                return "Nazmul";
            }
        }  
    }
