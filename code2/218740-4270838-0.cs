    <asp:GridView ID="gdvReport" runat="server" AutoGenerateColumns="False" DataSourceID="sdseport" OnRowDataBound="OnRowDataBound">
        <Columns>
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone">
                <ControlStyle Width="250px" />
            </asp:BoundField>
            <asp:BoundField DataField="ToCall" HeaderText="Foramt" SortExpression="ToCall" />
        </Columns>
    </asp:GridView>
    
  
    protected void OnRowDataBound(object sender, EventArgs e)
    {  
        GridViewRowEventArgs ea = e as GridViewRowEventArgs;
        if (ea.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ea.Row.DataItem as DataRowView;
            Object ob = drv["Phone"];
            if (!Convert.IsDBNull(ob))
            {
                bool iParsedValue = false;
                if (bool.TryParse(ob.ToString(), out iParsedValue))
                {
                    TableCell cell = ea.Row.Cells[1];
                    if (iParsedValue == false)
                    {
                        
                        cell.Text = "Don't Call";
                    }
                    else
                    {
                        cell.Text = "Call Us";
                    }
                    
                }
            }
        }
    }
