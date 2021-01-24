    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 100; i++)
        {
            lstDummies.Items.Add(new dummyItem());
            await Task.Delay(100);
        }
    }
