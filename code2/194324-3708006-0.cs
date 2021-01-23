    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        // disable cell selection
        foreach (DataGridViewCell cell in this.dataGridView1.SelectedCells)
            cell.Selected = false;
        // disable row selection
        foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            row.Selected = false;
        // disable column selection
        foreach (DataGridViewColumn col in this.dataGridView1.SelectedColumns)
            col.Selected = false;
    }
