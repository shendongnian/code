    DataTable datatable = new DataTable(); // your dt
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            ((Label)e.Row.Cells[0].Controls[1]).Text = datatable.Columns[0].ColumnName;
        }
    }
