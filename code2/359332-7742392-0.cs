    private int nameCellIndex = -1;
    private const string CellName = "Name";
    
    void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            for (int cellIndex = 0; cellIndex < e.Row.Cells.Count; cellIndex++)
            {
                if (e.Row.Cells[cellIndex].Text == CellName)
                {
                    nameCellIndex = cellIndex;
                    break;
                }
            }
        }
        else if (nameCellIndex != -1 && e.Row.RowType == DataControlRowType.DataRow)
        {
            string test = e.Row.Cells[nameCellIndex].Text;
        }
    }
