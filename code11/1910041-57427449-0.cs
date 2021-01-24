    public void RemoveCurrentItem()
    {
        if (comboBox1.SelectedIndex != -1)
        {
            comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
        }
        comboBox1.Text = null;
    }
