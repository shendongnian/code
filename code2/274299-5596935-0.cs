    var completionTimeModels =
    from timeline in processTimelines
    
    group timeline by timeline.LifecycleEventId into grouping
    let foo = lifecycleEvents.Where(i => i.LifecycleEventId == grouping.Key).First()
    select new CompletionTimeViewModel()
    {
        Name = foo.LifecycleEventName,
        DisplayName = foo.LifecycleEventDisplayName
    };
