    void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (!string.IsNullOrEmpty(dataGridView1[e.ColumnIndex, e.RowIndex].ErrorText))
        {
            DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            cell.ErrorText = string.Empty;
            cell.Style.Padding = (Padding)cell.Tag;
            cell.Tag = null;
        }
    }
