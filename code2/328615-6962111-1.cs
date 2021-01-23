    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="false" 
        OnItemDataBound="DataGrid1_DataBound">
        <Columns>
            <asp:BoundColumn DataField="IdPolicy" HeaderText="Policy" ReadOnly="True" />
            <asp:TemplateColumn HeaderText="Files">
                <ItemTemplate>
                    <asp:ListView ID="ListView1" runat="server" ItemPlaceholderID="Panel1">
                        <LayoutTemplate>
                            <asp:Panel ID="Panel1" runat="server" />
                        </LayoutTemplate>
                        <ItemTemplate>
                            <%# Container.DataItem %><br />
                        </ItemTemplate>
                    </asp:ListView>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        public class Policy
        {
            public int IdPolicy { get; set; }
            public List<string> Files { get; set; }
        }
    
        private List<Policy> _policies;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _policies = new List<Policy>();
                _policies.Add(new Policy
                {
                    IdPolicy = 1,
                    Files = new List<string> {"One.jpg", "Two.jpg"}
                });
    
                _policies.Add(new Policy
                {
                    IdPolicy = 2,
                    Files = new List<string> {"TwentyOne.jpg", "TwentyTwo.jpg"}
                });
    
                DataGrid1.DataSource = _policies;
                DataGrid1.DataBind();
            }
        }
    
        protected void DataGrid1_DataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var policy = e.Item.DataItem as Policy;
    
                var listView1 = e.Item.FindControl("ListView1") as ListView;
    
                listView1.DataSource = policy.Files;
                listView1.DataBind();
    
            }
        }
    }
 
