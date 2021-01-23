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
