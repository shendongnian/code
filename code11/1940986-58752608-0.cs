    private void Button_Click(object sender, RoutedEventArgs e)
    {
        listView.SetValue(VirtualizingStackPanel.VirtualizationModeProperty, VirtualizationMode.Recycling);
        listView.Visibility = Visibility.Visible;
    }
