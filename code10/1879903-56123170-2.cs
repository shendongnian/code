    enabledColumns = new List<DataGridViewColumn>()
    {
        dataGridView1.Columns[0],
        dataGridView1.Columns[2]
    };
---
    List<DataGridViewColumn> enabledColumns = null;
    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        if (enabledColumns is null) return;
        var dgv = sender as DataGridView;
        var currentCell = dgv.CurrentCell;
        if (!enabledColumns.Any(c => c.Index == currentCell.ColumnIndex))
        {
            var nextCol = enabledColumns.FirstOrDefault(c => c.Index > currentCell.ColumnIndex);
            if (nextCol != null) {
                dgv.CurrentCell = dgv[nextCol.Index, currentCell.RowIndex];
            }
            else
            {
                var previousCol = enabledColumns.First(c => c.Index < currentCell.ColumnIndex);
                dgv.CurrentCell = dgv[previousCol.Index, currentCell.RowIndex];
            }
        }
    }
