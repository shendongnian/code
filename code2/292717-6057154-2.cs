    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow dr = ((DataRowView)e.Row.DataItem).Row;
            TimeSpan ts = Convert.ToDateTime(dr["datereturned"]) - Convert.ToDateTime(dr["dateborrowed"]);
            ((Label)e.Row.FindControl("PenaltyAmountLable")).Text = ((ts.TotalDays) * Convert.ToDecimal(dr["PenaltyAmount"])).ToString();
        }
    }
