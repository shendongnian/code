    var startTime = new DateTime.Today().AddDays(-1); //When to start the minute interval buckets
    var callsBuckets =
        from time in Enumerable.Range(0, (60 * 24) // Minutes in a day
                               .Select(i => new DateTime(startTime).AddMinutes(i) // Create the times base on start time and current minute.
        select new // Create an anonymous type
        {
            // Create a property called Time, that stores the time checked
            Time = time,
            // Another property that stores the number of calls happening at that time.
            CallCount = Calls.Count(Call => Call.StartTime <= time && Call.StopTime >= time)
        };
