    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // default_asp NOT _Default as you might expect
            string typeName = this.GetType().Name;
        }
    }
