    private void rbBlank_Checked(object sender, RoutedEventArgs e)
    {
        // Verify source of event
        if (sender == rbBlank)
        {
            // Display
            comboBoxTitles.SelectedIndex = -1;
        }
    }
        
        
    private void comboBoxTitles_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        // Verify source of event
        if (sender == comboBoxTitles)
        {
            // Display
            rbBlank.IsChecked = false;
        }
    }
