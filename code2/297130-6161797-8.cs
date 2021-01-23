    public partial class SomeUserControl : System.Web.UI.UserControl
    {
        //create a public event on the delegate type defined in the namespace:
        public event setPageText reporter;
    
        public void Page_Load(object sender, EventArgs e)
        {
            //....
        }
    }
