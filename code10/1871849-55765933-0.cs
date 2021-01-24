    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex > -1)
        {
            string word = comboBox1.SelectedItem.ToString();
            table.DefaultView.RowFilter = "WordSets = '" + word + "'";
            dataGridView1.DataSource = table.DefaultView;
        }
    }
