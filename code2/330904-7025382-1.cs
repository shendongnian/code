    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var master = (this.Master as MyMaster);
            master.SelectedMenu = MenuItem.Home;
        }
    }
