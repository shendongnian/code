    public partial class _Default : System.Web.UI.Page
    {
        DropDownList[] dls = null;
    
        public _Default()
        { 
            dls = new DropDownList[] { dl1, dl2, dl3 };
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {            
        }
    }
