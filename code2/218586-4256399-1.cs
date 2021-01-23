    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        //Create and fill a list to use as the custom data source
        var source = new AutoCompleteStringCollection();
        source.AddRange(new string[] {"Apple", "Ball"});
        //Set the appropriate properties on the textbox control
        TextBox dgvEditBox = e.Control as TextBox;
        if (dgvEditBox != null)
        {
            dgvEditBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            dgvEditBox.AutoCompleteCustomSource = source
            dgvEditBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
    }
