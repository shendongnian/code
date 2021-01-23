    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label) e.Row.FindControl("Label1");
            if(lbl!=null)
            {
                lbl.Text = invoicetransmit.Invoice[0].LineItem[e.Row.RowIndex].Quantity.Value.ToString();
            }
        }
    }
