    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        System.Data.DataRow dr = ((System.Data.DataRowView)e.Row.DataItem).Row;
        if (dr["Percentage"].ToString() == "0")
        {
            ((Label)e.Row.FindControl("lblPercentage")).Text = "";
            //this is template field
            //OR---If you don't use template field you  can do like..--
            e.Row.Cells[1].Text  = "";
        }      
    }
    }
