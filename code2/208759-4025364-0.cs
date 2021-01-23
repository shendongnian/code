    protected void grvOutHour_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridView grid = (GridView)sender;
        CheckBox nextDay = (CheckBox)e.Row.FindControl("chkNextDay");
        nextDay.Visible = (e.Row.RowIndex == (grid.Rows.Count - 1));
    }
