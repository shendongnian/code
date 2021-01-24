    var merged = jsonSeriesList.Aggregate(
        new { datapoints = Enumerable.Empty<object[]>() },
        (m, j) => new
        {
            datapoints = m.datapoints.Concat(JsonConvert.DeserializeAnonymousType(j, m).datapoints)
                // Group them by the first array item.
                // This will throw an exception if any of the arrays are empty.
                .GroupBy(i => i[0])
                // And create a combined array consisting of the key (the first item from all the grouped arrays)
                // concatenated with all subsequent items in the grouped arrays.
                .Select(g => new[] { g.Key }.Concat(g.SelectMany(i => i.Skip(1))).ToArray())
        });
    var mergedJson = JsonConvert.SerializeObject(merged);
