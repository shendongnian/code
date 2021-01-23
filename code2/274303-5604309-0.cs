    var completionTimeModels =
        from timeline in processTimelines 
        group timeline by timeline.LifecycleEventId into grouping
        let lifecyleEvent = lifecycleEvents.First(i => i.LifecycleEventId == grouping.Key)
        select new CompletionTimeViewModel()
        {
            // How to avoid repeating the same query to find the life cycle event?
            Name = lifecyleEvent.LifecycleEventName
            DisplayName = lifecyleEvent.LifecycleEventDisplayName
        };
