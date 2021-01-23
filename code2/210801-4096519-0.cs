    protected void gridView_rowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.Header:
                foreach (DataColumn col in myDataTable.Columns)
                {
                    if (col.ExtendedProperties["error"] != null)
                    {
                        e.Row.Cells[col.Ordinal].CssClass = "error-cell";
                        e.Row.Cells[col.Ordinal].ToolTip = col.ExtendedProperties["error"].ToString();
                    }
                }                 
                break;
            case DataControlRowType.DataRow:
                
                break;
        }
    }
