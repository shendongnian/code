    private void button1_Click(object sender, EventArgs e)
    {
        var value = 3;
        var item = comboBox1.Items.Cast<Object>()
            .Where(x => comboBox1.GetItemValue(x).Equals(value))
            .FirstOrDefault();
        comboBox1.SelectedItem = item;
    }
