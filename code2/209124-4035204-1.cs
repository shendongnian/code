    INotifyPropertyChanged source;
    INotifyPropertyChanged target;
    // See the link at the bottom of my answer
    var sourcePropertyChanged = source.GetPropertyChangeValues(x => x.SourceProperty);
    // Unit is Rx's "void"
    var targetChangedLocally = new Subject<Unit>();
    var targetPropertyChanged = target.GetPropertyChangeValues(x => x.TargetProperty)
        .SkipWhen(targetChangedLocally);
    sourcePropertyChanged
        .TakeUntil(targetPropertyChanged)
        .ObserveOnDispatcher()
        .Subscribe(_ =>
        {
            targetChangedLocally.OnNext();
            /*Raises target.PropertyChanged for targetPropertyName*/
        });
