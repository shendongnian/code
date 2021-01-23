    public void ShowExtendedProperties(GridViewRow row, DataTable table)
    {
    switch (row.RowType)
        {
            case DataControlRowType.Header:
                foreach (DataColumn col in table.Columns)
                {
                    if (col.ExtendedProperties["error"] != null)
                    {
                        row.Cells[col.Ordinal].CssClass = "error-cell";
                        row.Cells[col.Ordinal].ToolTip = col.ExtendedProperties["error"].ToString();
                    }
                }                 
                break;
            case DataControlRowType.DataRow:
                //I assume you have logic here, or other case statements?
                break;
        }
    }
