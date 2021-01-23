    protected override void Render(HtmlTextWriter writer)
    {
        // ...
        spGridView.DataBind();
        if (spGridView.HeaderRow != null)
        foreach (TableCell cell in spGridView.HeaderRow.Cells)
            cell.CssClass = "spgridview-th";
        // ...
    }
