    from segment in RoadwaySegments
    join sample in IndividualSpeeds on new { segment.StartId, segment.EndId } equals new { sample.StartId, sample.EndId } into segmentSamples
    from startHour in Enumerable.Range(0, 24)
    from startMin in new[] { 0, 15, 30, 45 }
    let startMinSamples = segmentSamples
        .Where(sample => sample.Speed > 0)
        .Where(sample => sample.StartHour == startHour)
        .Where(sample => sample.StartMin == startMin)
        .Select(sample => sample.Speed)
        .ToList()
    select new SummaryItem
    {
        StartId = segment.StartId,
        EndId = segment.EndId,
        SummaryHour = startHour,
        SummaryMin = minute,
        AvgSpeed = startMinSamples.Count <= 2 ? 0 : startMinSamples.Average()
    };
