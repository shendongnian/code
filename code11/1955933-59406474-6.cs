    private async void Form1_Load(object sender, EventArgs e)
    {
        dataGridView1.ColumnCount = 3;
        dataGridView1.RowCount = 3;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
        dataGridView1.CellClick += DataGridView1_CellClick;
        dataGridView1.EnableHeadersVisualStyles = false;
    }
    DataGridViewColumn selectedColumn = null;
    DataGridViewRow selectedRow = null;
    List<DataGridViewCell> selectedCells = null;
    private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        dataGridView1.ClearSelection();
        if (selectedColumn != null)
            selectedColumn.HeaderCell.Style.BackColor =
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor;
        if (selectedRow != null)
            selectedRow.HeaderCell.Style.BackColor =
                dataGridView1.RowHeadersDefaultCellStyle.BackColor;
        selectedColumn = null;
        selectedRow = null;
        selectedCells = null;
        if (e.ColumnIndex == -1 && e.RowIndex == -1)
        {
            dataGridView1.SelectAll();
            selectedCells = new List<DataGridViewCell>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
                selectedCells.AddRange(row.Cells.Cast<DataGridViewCell>());
        }
        else if (e.ColumnIndex == -1 && e.RowIndex > -1)
        {
            selectedRow = dataGridView1.Rows[e.RowIndex];
            foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                cell.Selected = true;
        }
        else if (e.ColumnIndex > -1 && e.RowIndex == -1)
        {
            selectedColumn = dataGridView1.Columns[e.ColumnIndex];
            foreach (DataGridViewRow row in dataGridView1.Rows)
                row.Cells[e.ColumnIndex].Selected = true;
        }
        else
        {
            selectedCells = selectedCells = new List<DataGridViewCell>()
                { dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] };
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }
        if (selectedColumn != null)
            selectedColumn.HeaderCell.Style.BackColor = SystemColors.Highlight;
        if (selectedRow != null)
            selectedRow.HeaderCell.Style.BackColor = SystemColors.Highlight;
    }
