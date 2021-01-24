    var performanceAnchors = initialTrainingResults
        // Group by each unique Performance Anchor. Remember, the IEnumerable
        // we are operating on contains our anonymous type of combined Training,
        // Performance Anchor and Grading data.
        .GroupBy(x => x.PerformanceAnchor.Id)
        // Order each Performance Anchor group by the dates of its training,
        // and take the first one from each group
        .Select(g => g.OrderByDescending(x => x.InitialTraining.DateTakenInitial).First());
