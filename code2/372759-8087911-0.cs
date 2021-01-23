    Subject<DateTime> allActivities = new Subject<DateTime>();
    var activitySubscriptions = new CompositeDisposable();
    activitySubscriptions.Add(mouseMoveActivity.Subscribe(allActivities));
    activitySubscriptions.Add(mouseLeftButtonActivity.Subscribe(allActivities));
    //etc ...
    //subscribe to activities
    allActivities.Throttle(timeSpan)
                 .Subscribe(timeoutAction);
                 
    //later add another
    activitySubscriptions.Add(newActivity.Subscribe(allActivities));
