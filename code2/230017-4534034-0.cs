    if(e.Row.RowType == DataControlRowType.DataRow)
    {
        if(String.IsNullOrEmpty(s.trim()))
        {
            return;
        }
        row.CssClass = "newRowBackground";
    }
