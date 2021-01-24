    void ChangeCellType(DataGridViewCell c)
    {
        var index = c.OwningColumn.Index;
        var cells = c.OwningRow.Cells;
        var newCell = new DataGridViewCheckBoxCell();
        newCell.ValueType = typeof(bool);
        newCell.Value = true;
        cells[index] = newCell;
    }
