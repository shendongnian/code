    private void On_Navigated(object sender, NavigationEventArgs e)
    {
        if (ContentFrame.Content?.GetType() == typeof(SettingsPage))
        {
            navView.SelectedItem = (NavigationViewItem)navView.SettingsItem;
            navView.Header = "Settings";
        }
        else if (ContentFrame.Content != null)
        {
            ...
        }
    }
