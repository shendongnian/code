    private void button1_Click(object sender, EventArgs e)
    {
        var value = 3;
        var item = comboBox1.Items.Cast<Object>()
            .Where(x => (int)comboBox1.GetItemValue(x) == value)
            .FirstOrDefault();
        var index = comboBox1.Items.IndexOf(item);
        comboBox1.SelectedIndex = index;
    }
