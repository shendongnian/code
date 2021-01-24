    var linqable = dataGridView2.Rows.Cast<DataGridViewRow>().Select((r, y) => new
    {
        row = r,
        rowNum = y,
        cells = r.Cells.Cast<DataGridViewCell>().Select((a, b) =>
        new
        {
            cell = a,
            cellNum = b
        })
    });
    
    foreach(var row in linqable)
    {
        foreach(var cellWithRed in row.cells.Where(x => x.cell.Style.BackColor == Color.Red))
        {
            dataGridView3.Rows[row.rowNum].Cells[cellWithRed.cellNum].Value = cellWithRed.cell.Value;
        }
    }
