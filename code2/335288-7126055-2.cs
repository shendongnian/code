<asp:Button CommandArgument="2" CommandName="Fetch" ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    protected void FetchImages(Object src, GridViewCommandEventArgs e)
    {
         if(e.CommandName == "Fetch")
       {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow selectedRow = ((GridView)e.CommandSource).Rows[index];
        string dateGV = selectedRow.Cells[2].Text;
        string accountGV = selectedRow.Cells[3].Text;
        string amountGV = selectedRow.Cells[4].Text;
        string docGV = selectedRow.Cells[5].Text;
        string txnGV = selectedRow.Cells[6].Text;
        string seqGV = selectedRow.Cells[7].Text;
       }
    }
