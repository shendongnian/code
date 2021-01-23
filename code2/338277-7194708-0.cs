    // This event handler manually raises the CellValueChanged event
    // by calling the CommitEdit method.
    void dataGridView1_CurrentCellDirtyStateChanged(object sender,
        EventArgs e)
    {
        if (dataGridView1.IsCurrentCellDirty)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
