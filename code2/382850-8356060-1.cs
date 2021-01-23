    namespace SO_Questions
    {
        public partial class TestPage : System.Web.UI.Page
        {
            protected QuickShopBag QuickShopBagInstance
            {
                get { return (QuickShopBag)ViewState["QuickShopBag"]; }
                set { ViewState["QuickShopBag"] = value; }
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    this.QuickShopBagInstance = new QuickShopBag() { MyProperty = "Test String" };
                }
                Message.Text = "Value is: " + this.QuickShopBagInstance.MyProperty.ToString();
            }
    
            protected override void LoadViewState(object savedState)
            {
                base.LoadViewState(savedState);
            }
            protected void btnSubmit_Click(object sender, EventArgs e)
            {
                btnSubmit.Text += QuickShopBagInstance.MyProperty;
            }
        }
    }
