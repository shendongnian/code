    void colorCells(GridView GV, int CellIndex, string Text)
    {
        foreach(GridViewRow row in GV.Rows)
        {
            if(row.Cells[CellIndex].Text == Text)
                row.Cells[CellIndex].BackColor = System.Drawing.Color.Red;
            //might use else to set to default color
        }
    }
