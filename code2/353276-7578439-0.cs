    bool isUserMessageBoxShown = false;
    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        if (!isUserMessageBoxShown)
        {
            MessageBox.Show("User Control Loaded.","WPF");
            isUserMessageBoxShown  = true; 
        }
    }
