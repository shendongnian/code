    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[column_index].ToolTip = "Click here to edit section"; // for cell
            ((ImageButton)e.Row.Cells[column_index].Controls[control_index]).ToolTip = "Click here to edit section"; // for ImageButton
        }
    }
