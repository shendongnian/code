    namespace YourProject
    {
        public partial class a : System.Web.UI.MasterPage
        {
            protected void Page_Load(object sender, EventArgs e)
    	    {
               b contentPage = (b)this.Page;
               contentPage.Foo("Hello");
            }
           
            ....
        }
    }
 
