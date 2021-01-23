    private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string ob = ((DataRowView)comboBox1.SelectedItem).Row.ItemArray[0].ToString();
        MessageBox.Show(ob);
    }
