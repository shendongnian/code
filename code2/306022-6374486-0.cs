    <%@ Page Language="C#" AutoEventWireup="true" %>
    <html>
    <body>
        <form id="form1" runat="server">
            <asp:ListView ID="listView1" runat="server">
                <ItemTemplate>
                    <asp:Label ID="myLabel" Text="<%# Container.DataItem %>" runat="server" /><br />
                </ItemTemplate>
            </asp:ListView>
            <asp:Button ID="btnGatherLabels" Text="Gather Labels" OnClick="btnGatherLabels_Click" runat="server" />
        </form>
    </body>
    </html>
    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                var myItems = new[] { "item1", "item2", "item3" };
                listView1.DataSource = myItems;
                listView1.DataBind();
            }
        }
        
        public void btnGatherLabels_Click(object sender, EventArgs e)
        {
            var myLabels = listView1.Items
                            .Where(i => i.ItemType == ListViewItemType.DataItem)
                            .Select(a => a.FindControl("myLabel"));
            foreach(Label myLabel in myLabels)
                Response.Write(string.Concat(myLabel.Text, "<br />"));
        }
    </script>
