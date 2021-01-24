    Parallel.ForEach(list, new ParallelOptions() { MaxDegreeOfParallelism = 2 }, index => 
    {
        var response = client.GetAsync("posts/" + index).Result;
        var contents = response.Content.ReadAsStringAsync().Result;
        listResults.Add(contents);
        Console.WriteLine(contents);
    });
