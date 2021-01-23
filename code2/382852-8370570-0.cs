    <form id="form1" runat="server">
    <div>
        <asp:ListView id="QuickshopListView" runat="server">
            <LayoutTemplate>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </LayoutTemplate>
            <ItemTemplate>
                <asp:TextBox ID="txtItem" runat="server" Text='<%# Container.DataItem %>' />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                <br />
            </ItemTemplate>
        </asp:ListView>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
    </div>
    </form>
    public partial class Quickshop : System.Web.UI.Page
    {
        protected QuickShopBag QuickShopBagInstance
        {
            get { return (QuickShopBag)ViewState["QuickShopBag"]; }
            set { ViewState["QuickShopBag"] = value; }
        }
    
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (QuickShopBagInstance == null)
                    QuickShopBagInstance = new QuickShopBag();
    
                if (!String.IsNullOrEmpty(Request.QueryString.ToString()))
                {
                    string[] items = Server.UrlDecode(Request.QueryString.ToString()).Split(',');
                    if (items.Length > 0)
                    {
                        foreach (string item in items)
                        {
                            QuickShopBagInstance.QuickShopItems.Add(item);
                        }
                    }
                }
            }
        }
    
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            QuickshopListView.DataSource = QuickShopBagInstance.QuickShopItems;
            QuickshopListView.DataBind();
        }
    
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (QuickShopBagInstance == null)
                QuickShopBagInstance = new QuickShopBag();
    
            QuickShopBagInstance.QuickShopItems.Add("add1");
            QuickShopBagInstance.QuickShopItems.Add("add2");
            QuickShopBagInstance.QuickShopItems.Add("add3");
        }
    
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button DeleteButton = (Button)sender;
            ListViewDataItem item = (ListViewDataItem)DeleteButton.NamingContainer;
            QuickShopBagInstance.QuickShopItems.RemoveAt(item.DisplayIndex);
        }
    }
    [Serializable]
    public class QuickShopBag
    {
        public List<string> QuickShopItems { get; set; }
    
        public QuickShopBag()
        {
            this.QuickShopItems = new List<string>();
        }
    }
