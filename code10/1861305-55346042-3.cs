    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        dataGridView1.Invalidate();
    }
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
