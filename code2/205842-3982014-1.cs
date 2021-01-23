    // low level observables
    var dataSourceLoading = ... // "loading" observable
    var dataSourceLoaded = ... // "loaded" observable
    var textChange = Observable.FromEvent<TextChangedEventArgs>(MyTextBox, "TextChanged");
    var click = Observable.FromEvent<RoutedEventArgs>(MyButton, "Click");
    // higher level observables
    var text = textChange.Select(_ => MyTextBox.Text.Trim());
    var emptyText = text.Select(String.IsNullOrWhiteSpace);
    var searchInProgress = dataSourceLoading.Select(_ => true).Merge(dataSourceLoaded.Select(_ => false));
    // enable/disable controls
    searchInProgress.Merge(emptyText)
        .ObserveOnDispatcher()
        .Subscribe(v => MyButton.IsEnabled = !v);
    searchInProgress
        .ObserveOnDispatcher()
        .Subscribe(v => MyTextBox.IsEnabled = !v);
    // load data 
    click
        .CombineLatest(text, (c,t) => new {c,t})
        .DistinctUntilChanged(ct => ct.c)
        .Subscribe(ct => LoadData(ct.t));
