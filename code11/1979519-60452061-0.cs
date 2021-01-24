    private void Button_Register(object sender, RoutedEventArgs e)
    {
        Registration registration = new Registration();
        registration.ShowDialog();
        if (registration.LogIn == true)
        {
            StartButton.Visibility = registration.LogIn ? Visibility.Visible : Visibility.Hidden;
        }
    }
