    from segment in RoadwaySegments
    join sample in IndividualSpeeds on new { segment.StartId, segment.EndId } equals new { sample.StartId, sample.EndId } into segmentSamples
    from hour in Enumerable.Range(0, 24)
    from quarter in new[] { 0, 15, 30, 45 }
    select new SummaryItem
    {
        StartId = segment.StartId,
        EndId = segment.EndId,
        SummaryHour = hour,
        SummaryMin = minute,
        AvgSpeed = segmentSamples.Where(sample => sample.Speed > 0).Average(sample => sample.Speed)
    };
