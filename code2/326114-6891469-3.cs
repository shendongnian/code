    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        if (this.dataGridView2.DataSource != null)
        {
            this.dataGridView2.DataSource = null;
        }
        else
        {
            this.dataGridView2.Rows.Clear();
        }
        for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
        {
            int index = dataGridView2.Rows.Add();
            dataGridView2.Rows[index].Cells[0].Value = dataGridView1.SelectedRows[i].Cells[0].Value.ToString();
            dataGridView2.Rows[index].Cells[1].Value = dataGridView1.SelectedRows[i].Cells[1].Value.ToString();
            .....
        }
    }
