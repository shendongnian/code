    MessageBoxResult result = MessageBox.Show("Do you want to close this window?",
                                              "Confirmation",
                                              MessageBoxButton.YesNo,
                                              MessageBoxImage.Question);
    if (result == MessageBoxResult.Yes)
    {
        Application.Current.Shutdown();
    }
