    private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (comboBoxTitles.SelectedIndex != -1)
        {
            rbBlank.IsChecked = false;
        }
    }
