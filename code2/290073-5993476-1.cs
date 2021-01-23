    private void cmbPlatform_SelectedIndexChanged(object sender, EventArgs e)
    {
        var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
        string platform = cmbPlatform.Text;
        UpcomingGameFinder gameFinder = new UpcomingGameFinder();
        Task.Factory.StartNew<IEnumerable<Game>>(() => gameFinder.FindUpcomingGamesByPlatform(platform))
            .ContinueWith((i) => PlaceGameItemsInPanel(i.Result), uiContext);        
    }    
