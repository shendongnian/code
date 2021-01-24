    baseQuery = baseQuery.Where(s => s.LearningActions.SelectMany(la => la.ProgressUpdates)
                         .GroupBy(d => d.LearningActionId)
                         .Select(a => a.Any() ? new { Max = a.Max(d => d.Progress) } : new { Max = 0})
                         .DefaultIfEmpty(defaultItem)
                         .Average(d => d.Max) < averageProgress.GetValueOrDefault());
