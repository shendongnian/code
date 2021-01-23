    The code below shows the contents of an aspx file, which contains two label controls, and two SqlDataSource controls. Each SqlDataSource control has its DataSource mode set to alternative values - DataSet and DataReader, and both of them have an OnSelecting event defined in which the value of the EmployeeID parameter is assigned:
    
    <asp:Label ID="Label1" runat="server" /> <asp:Label ID="Label2" runat="server" />
    
    <asp:SqlDataSource 
    	ID="SqlDataSource1" 
    	runat="server" 
    	ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    	ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    	DatasourceMode="DataSet"
    	SelectCommand="SELECT [LastName], [FirstName] FROM [Employees] WHERE ([EmployeeID] = ?)" 
    	OnSelecting="SqlDataSource1_Selecting">
        <SelectParameters>
            <asp:Parameter Name="EmployeeID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <asp:SqlDataSource
    	ID="SqlDataSource2" 
    	runat="server"
    	ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    	ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    	DatasourceMode="DataReader"
    	SelectCommand="SELECT [LastName], [FirstName] FROM [Employees] WHERE ([EmployeeID] = ?)" 
    	OnSelecting="SqlDataSource2_Selecting">
        <SelectParameters>
            <asp:Parameter Name="EmployeeID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    The following code snippet shows the aspx.cs file contents, where the parameter values are set in the Selecting event handler. In the Page_Load method, the data returned by each of the Sql DataSource controls is accessed and a value consigned to a label. The method of access depends on the DataSource mode, but is identical for both SqlDataSource and AccessDataSource:
    
    [C#]
    protected void Page_Load(object sender, EventArgs e)
    {
    
        DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {
            Label1.Text = drvSql["FirstName"].ToString();
        }
    
        OleDbDataReader rdrSql = (OleDbDataReader)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        while (rdrSql.Read())
        {
            Label2.Text = rdrSql["LastName"].ToString();
    
        }
        rdrSql.Close();
    }
    
    
    
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["EmployeeID"].Value = 2;
    }
    
    protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["EmployeeID"].Value = 2;
    }
