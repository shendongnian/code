    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow dr = ((DataRowView)e.Row.DataItem).Row;
            ((Button)e.Row.FindControl("select_button")).CommandArgument = dr["IdColumn"].ToString();
        }
    }
