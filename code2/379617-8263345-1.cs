    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (PhoneApplicationService.Current.State.ContainsKey("name"))
            textBox1.Text = (string)PhoneApplicationService.Current.State["name"];
    }
