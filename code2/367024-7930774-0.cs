    dataGridView1.CurrentCellDirtyStateChanged += new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);
    dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
    void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (dataGridView1.Columns[e.ColumnIndex].Name == "CB")
        {
            MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());    
        }
    }
    
    void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
