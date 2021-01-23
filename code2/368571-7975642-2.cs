    <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField DataField="Column1" />
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Literal runat="server" Text='<%#EnumToString(Eval("Status")) %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    //My Enum definition
    public enum EStatus
    {
        Pending,
        Ready,
        Ordered,
        AwaitingApproval,
        PaymentWaiting
    }
    //this is how I populate my grid with dummy data
    private void bindGridView()
    {
        DataTable t = new DataTable();
        t.Columns.Add("Column1");
        t.Columns.Add("Status");
        DataRow r = null;
        for (int i = 0; i < 10; i++)
        {
            r = t.NewRow();
            if(i%2==0)
                r.ItemArray = new object[] { "Name "+i,  EStatus.AwaitingApproval};
            else
                r.ItemArray = new object[] { "Name " + i, EStatus.PaymentWaiting };
    
            t.Rows.Add(r);
        }
        GridView1.DataSource = t;
        GridView1.DataBind();
    }
