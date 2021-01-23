    private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
    {
        if (e.StateChanged == DataGridViewElementStates.Selected)
            e.Row.DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
    }
    private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
    {
        if (e.StateChanged == DataGridViewElementStates.Selected)
            // adjust the edit mode to your "default" edit mode if you have to
            e.Cell.DataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
    }
