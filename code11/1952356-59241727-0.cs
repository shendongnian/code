    var tasks = someDataList.Select(i => _req.ExecuteAsync(i) );
    await Task.WhenAll(tasks);
    var dict = tasks.ToDictionary(t=> t.Result);
    if (dict.Count == List.count()
    {
        //execute part 2.
    }
