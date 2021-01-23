    var startTime = new DateTime.Now().AddDays(-1); //When to start the minute interval buckets
    var sallsBuckets =
        from time in Enumerable.Range(0, (60 * 24) // Minutes in a day
                               .Select(i => new DateTime(startTime).AddMinutes(i)
        select new { Time = time, CallCount = Calls.Count(Call => Call.StartTime <= time && Call.StopTime >= time) }; // Count the number of calls happening at that time.
