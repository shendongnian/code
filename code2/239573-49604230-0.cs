    var deduplicated = inputs
        .GroupBy(input => input)
        .Select(group =>
            group
            .Select(input => Observable.Return(input).Delay(TimeSpan.FromSeconds(5)))
            .Switch())
        .Merge(); // <-- This is added to combine the partitioned results
