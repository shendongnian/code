<asp:Panel ID="x" Visible="false" runat="server" Height="338px">
    <%--<asp:Table ID="orders" CellPadding="4" runat="server" Height="67px" Width="316px"></asp:Table>--%>
    <asp:GridView ID="gvOrders" CellPadding="4" runat="server" Height="67px" Width="316px"></asp:GridView>
</asp:Panel>
Now, in the code-behind there are a couple changes. A `DataTable` can be used to store the results of your query and then you can bind a `DataTable` to a `GridView`. To do this, you need a `SqlDataAdapter` which is shown below. 
protected void reviewOrders(object sender, EventArgs e)
{
    // data table variable outside of sql block
    // you could also move the sql code to another method that returns a datatable
    DataTable dt = null;
    string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
    using (SqlConnection conn = new SqlConnection(connStr))
    {
        SqlCommand cmd = new SqlCommand("reviewOrders", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        using (cmd)
        {
            conn.Open();
                 
            // Use SQL Data Adapter instead of Execute Non Query
            using (SqlDataAdapter _Adapter = new SqlDataAdapter(cmd))
            {
                // Fill DataTable with results of query
                dt = new DataTable();
                _Adapter.Fill(dt);
            }
        }
    }
    //
    
    gvOrders.DataSource = dt;
    gvOrders.DataBind();
}
Note: I use `using(SqlConnection)` and `using(cmd)` to handle closing the connection and command for me. Give this a shot.
