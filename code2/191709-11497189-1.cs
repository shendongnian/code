    private void MenuItemWithRadioButtons_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        MenuItem mi = sender as MenuItem;
        if (mi != null)
        {
            RadioButton rb = mi.Icon as RadioButton;
            if (rb != null)
            {
                rb.IsChecked = true;
            }
        }
    }
