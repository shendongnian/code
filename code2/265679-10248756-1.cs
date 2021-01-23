    protected void gvSearchResults_DataBound(object sender, EventArgs e)
    {
        GridView gridView = (GridView)sender;
        if (gridView.HeaderRow != null && gridView.HeaderRow.Cells.Count > 0)
        {
            gridView.HeaderRow.Cells[UserIdColumnIndex].Visible = false;
        }
        foreach (GridViewRow row in gvSearchResults.Rows)
        {
            row.Cells[UserIdColumnIndex].Visible = false;
        }
    }
