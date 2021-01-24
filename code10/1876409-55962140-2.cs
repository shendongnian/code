    private void button6_Click(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex >= 0)
        {
            checkedListBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
        }
    }
