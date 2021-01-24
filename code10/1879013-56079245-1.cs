    private void comboBoxTag_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the name of the DataGridView which should be visible:
        string selectedTagDB = comboBoxTagDatabases.SelectedItem.ToString();
        ShowOneDataGridViewAndHideOthers(selectedTagDB);
    }
