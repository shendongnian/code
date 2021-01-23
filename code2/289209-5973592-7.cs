    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (MediaButton.Content == FindResource("Play"))
        {
            MediaButton.Content = FindResource("Stop");
        }
        else
        {
            MediaButton.Content = FindResource("Play");
        }
    }
