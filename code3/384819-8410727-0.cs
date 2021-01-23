    <asp:Button ID="button1" runat="server" OnClick="AddRow" />
    <asp:Table id="aTable" name="aTable" runat="server">  
        <asp:TableHeaderRow>  
            <asp:TableHeaderCell>1</asp:TableHeaderCell> 
        </asp:TableHeaderRow> 
    </asp:Table>
    protected void AddRow(object sender, EventArgs e)
    {
        TableRow row = new TableRow();
        TableCell cell = new TableCell();
        cell.Text = "hello";
        row.Cells.Add(cell);
    
        aTable.Rows.Add(row);
    }
