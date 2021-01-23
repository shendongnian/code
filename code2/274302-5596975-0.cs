    var completionTimeModels =
        from timeline in processTimelines
        group timeline by timeline.LifecycleEventId into grouping
        let lifecyleEvent = lifecycleEvents.Where(i => i.LifecycleEventId == grouping.Key).First()
        select new CompletionTimeViewModel()
        {
            Name = lifecyleEvent.LifecycleEventName,
            DisplayName = lifecyleEvent.LifecycleEventDisplayName
        };
