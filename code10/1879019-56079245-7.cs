    private void ShowOneControlAndHideOthers<T>(string name, Control controls) where T : Control
    {
        foreach (var control in controls.Controls.OfType<T>())
        {
            control.Visible = control.Name == name;
        }
    }
    private void comboBoxTag_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the name of the DataGridView which should be visible:
        string selectedTagDB = comboBoxTagDatabases.SelectedItem.ToString();
        ShowOneControlAndHideOthers<DataGridView>(selectedTagDB, this);
    }
