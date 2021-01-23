    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        while (NavigationService.BackStack.Any())
        {
            NavigationService.RemoveBackEntry();
        }
    }
