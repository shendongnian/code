    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((Label)e.Row.Cells[0].FindControl("ValueHoldingControl").Text == "ABC")
            {
                //Coloring the cell
            }
        }
    }
