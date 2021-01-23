    var completionTimeModels =
        from timeline in processTimelines 
        group timeline by timeline.LifecycleEventId into grouping
        let current = lifecycleEvents.Where(i => i.LifecycleEventId == grouping.Key).First()
        select new CompletionTimeViewModel()
        {
                // How to avoid repeating the same query to find the life cycle event?
            Name = current.LifecycleEventName,
            DisplayName = current.LifecycleEventDisplayName
        };
