    public enum MenuItem
    {
        Home,
        Import,
        InsertSubmission,
        Reports,
        CurrencyMaintenance,
        Remittance
    }
    
    public partial class MyMaster : System.Web.UI.MasterPage
    {
        public MenuItem SelectedMenu { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // You can either generate your entire menu from here or
            // you could just use the
            // <a href="Default.aspx" class='<%= this.SelectedMenu == MenuItem.Home ? "selected" : "" %>'>Home</a>
         }
    }
