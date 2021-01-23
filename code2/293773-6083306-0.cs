    private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        radioButton1.IsEnabled = comboBox1.SelectedItem == x;
        // or
        radioButton1.IsEnabled = comboBox1.SelectedValue == x;
    }
