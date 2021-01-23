    const string message =
            "Are you sure that you would like to close the form?";
    const string caption = "Form Closing";
    MessageBoxResult result = MessageBox.Show(message, caption,
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Question);
    if (result == MessageBoxResult.No)
    {
        // Do something for No
    }
    else if (result == MessageBoxResult.Yes)
    {
        // Do something else for Yes
    }
