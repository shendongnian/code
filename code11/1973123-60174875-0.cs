var steps = list
    .Where(s => !string.IsNullOrWhitespace(s.StepId))
    .GroupBy(s => (s.StepId, s.WorkId))
    .Select(grp => new {
        StepId = grp.Key.Item1,
        WorkId = grp.Key.Item2,
        Names = grp.Select(s => s.Name).ToList()
    });
