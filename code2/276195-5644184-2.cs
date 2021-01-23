    protected void GridView1_RowDataBound(object o, GridViewRowEventArgs e)
    {
        //Assumes the Price column is at index 4
        if(e.Row.RowType == DataControlRowType.DataRow)
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
    }
