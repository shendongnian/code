    private void button6_Click(object sender, EventArgs e)
    {
        string currentItem = comboBox1.GetItemText(comboBox1.SelectedItem);
        if (!string.IsNullOrEmpty(currentItem))
        {
             checkedListBox1.Items.RemoveAt(checkedListBox1.Items.IndexOf(currentItem));
             comboBox1.Items.Remove(comboBox1.SelectedItem);
        }
    }
