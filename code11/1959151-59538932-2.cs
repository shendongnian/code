    for (int columnIndex = 0; columnIndex < dGvTopics.Columns.Count; columnIndex ++)
    {
        if (dataGridView2.Rows[columnIndex].Cells[0].Value.ToString().Contains(dGvTopics.Columns[columnIndex].HeaderText))
        {
            this.dGvTopics.Rows.Add();
            this.dGvTopics.Rows[columnIndex].Cells[columnIndex].Value = dataGridView2.Rows[columnIndex].Cells[0].Value;
        }
    }
