    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        await Click_Helper(sender, e);
        System.Diagnostics.Debug.WriteLine(_res.ToString());
       
    }
