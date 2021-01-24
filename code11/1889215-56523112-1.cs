    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        grid.DataContext = new BaseViewModel();
        flipView.SelectionChanged += FlipView_SelectionChanged;
    }
