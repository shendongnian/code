    Parallel.ForEach(list, new ParallelOptions() { MaxDegreeOfParallelism = 2 }, index => Task.Run(async () =>
    {
        var response = await client.GetAsync("posts/" + index);
        var contents = await response.Content.ReadAsStringAsync();
        listResults.Add(contents);
        Console.WriteLine(contents);
    }).GetAwaiter().GetResult();
