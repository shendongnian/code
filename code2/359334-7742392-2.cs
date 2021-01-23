    private int nameCellIndex = -1;
    private const string CellName = "Name";
    
    void Button1_Click(object sender, EventArgs e)
    {
        for (int cellIndex = 0; cellIndex < GridView1.HeaderRow.Cells.Count; cellIndex++)
        {
            if (GridView1.HeaderRow.Cells[cellIndex].Text == CellName)
            {
                nameCellIndex = cellIndex;
                break;
            }
        }
    
        if (nameCellIndex != -1)
        {
            foreach (var row in GridView1.Rows.OfType<GridViewRow>().Where(row => row.RowType == DataControlRowType.DataRow))
            {
                string test = row.Cells[nameCellIndex].Text;
            }
        }
    }
