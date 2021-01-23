    private void UseDefaultFoldersCB_Checked(object sender, RoutedEventArgs e)
    {
        if (StartDirLocationTB != null && StartDirLocationTB.IsEnabled == false)
        {
             StartDirLocationTB.IsEnabled = true;
        }
        if (SelectStartLocationBtn != null && SelectStartLocationBtn.IsEnabled == false)
        {
             SelectStartLocationBtn.IsEnabled = true;
        }
    }
