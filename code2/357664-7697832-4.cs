    private void stateslistBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        string item = "";
        item = Convert.ToString(stateslistBox.SelectedItem);
        if (!string.IsNullOrEmpty(item)
        {
            statescomboBox.Items.Add(item);
            stateslistBox.Items.Remove(stateslistBox.SelectedItem);
        }
    }
