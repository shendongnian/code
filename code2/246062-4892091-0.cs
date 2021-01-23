    protected void GridViewSelections_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow) && (e.Row.RowState.HasFlag(DataControlRowState.Edit) && (e.Row.DataItem != null)))
        {
            DropDownList ddlOptions = e.Row.FindControl("ddlOptions") as DropDownList;
            ddlOptions.Items.Add(new ListItem("aaa", "1"));
            ddlOptions.Items.Add(new ListItem("bbb", "2"));
            ddlOptions.Items.Add(new ListItem("ccc", "3"));
