    public partial class BlockControl : System.Web.UI.UserControl
    {
        //Note the public property, we'll use this to data bind the ListView's item to the user control
        public Block Block { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
