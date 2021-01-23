    void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        TextBox dgvEditBox = e.Control as TextBox;
        if (dgvEditBox != null)
        {
            dgvEditBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            dgvEditBox.AutoCompleteSource = AutoCompleteSource.FileSystem;
        }
    }
