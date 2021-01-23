    <asp:Repeater runat="server" ID="MyRepeater" >
        <ItemTemplate>
            <uc1:MyItems ID="MyItems1" MyItems="<%# Eval("Name") %>" ... runat="server"  />
        </ItemTemplate>
    </asp:Repeater>
    protected void Page_Load(object sender, EventArgs e)
    {
        MyDataSource.SelectCommand =
                    "SELECT Name, Address, Phone " +
                    "FROM TestTable ";
        MyDataSource.SelectCommandType = SqlDataSourceCommandType.Text;
        DataView resultsdv = (DataView)MyDataSource.Select(DataSourceSelectArguments.Empty);
        MyRepeater.DataSource = resultsdv.Table.Rows;
        MyRepeater.DataBind()
    
    }
