    var uiThread = TaskScheduler.FromCurrentSynchronizationContext();
    Task.Factory.StartNew(() =>
    {
        // I assumed that It returns boolean value
        _scecoBillDataScope.FetchData();
    }).ContinueWith(x =>
    {
        // Here you can put the code to work on the UI thread.
        if (x.Result)
        {
              var collectionView = CollectionViewSource.GetDefaultView(_scecoBillDataScope.ScecoBills);
              LayoutRoot.DataContext = collectionView;
        }
    }, uiThread);
