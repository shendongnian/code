    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTotal = (Label)e.Row.FindControl("lblTotal");
            int iCount; 
            if (Decimal.TryParse(lblTotal.Text, iCount) ) {
                 iCount += iCount;
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalAmt = (Label)e.Row.FindControl("lblTotalAmt");
            lblTotalAmt.Text =  iCount.ToString();
        }
    }     
