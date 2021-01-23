    private void dgvObjectives_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (dgvObjectives.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
        {
            dgvObjectives.EndEdit();
        }
    }
