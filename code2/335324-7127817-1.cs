    private DataGridViewRow[] CloneDataGridViewRows(DataGridView dgv) {
        var rowArray = new DataGridViewRow[dgv.Rows.Count];
        for (int i = 0; i < dgv.Rows.Count; i++) {
            DataGridViewRow clonedRow = (DataGridViewRow)dgv.Rows[i].Clone();
            for (int c = 0; c < clonedRow.Cells.Count; c++) {
                clonedRow.Cells[c].Value = dgv.Rows[i].Cells[c].Value;
            }
            rowArray[i] = clonedRow;
        }
        return rowArray;
    }
