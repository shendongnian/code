    protected void grData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
	    if (e.Row.RowType == DataControlRowType.DataRow)
	    {
		    int i = ((DataTable)((GridView)sender).DataSource).Columns.IndexOf("Price");
		    for (int j = 0; j < e.Row.Cells.Count; j++)
		    {
			    if (j == i)
				    e.Row.Cells[j].HorizontalAlign = HorizontalAlign.Right;
			    else
				    e.Row.Cells[j].HorizontalAlign = HorizontalAlign.Left;
		    }
	   }
    }
