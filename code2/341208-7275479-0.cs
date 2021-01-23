    static public void HideColumn(GridView gv, int columnIndex)
    {
        if (gv.HeaderRow != null)
            gv.HeaderRow.Cells[columnIndex].Style.Add("display", "none");
        foreach (GridViewRow row in gv.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
                row.Cells[columnIndex].Style.Add("display", "none");
        }
    }
