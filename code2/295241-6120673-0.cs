    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow dr = ((DataRowView)e.Row.DataItem).Row;
            if(dr["ColumnName"].ToString() == "1" )
            {
              ((Label)e.Row.FindControl("lbl")).Text = "FSL";
            }
            else if(dr["ColumnName"].ToString() == "2" )
            {
              ((Label)e.Row.FindControl("lbl")).Text = "BTD";
            }
        }
    }
