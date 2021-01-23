    <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="False" 
         DataSourceID="SqlDataSource3" OnRowDataBound="ChangeRowColor">
    
    protected void ChangeRowColor(object sender, GridViewRowEventArgs e)
    {
       if( ((DataRow)e.Row.DataItem)[1] == .5)
       {
         e.Row.Cell[1].BackColor = Colors.Green;
       }
    }
