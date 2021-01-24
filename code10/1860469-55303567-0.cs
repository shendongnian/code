    var getData = new ActionBlock<JsonPDFReader.File>(items =>
    {
        //Code Here
    }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = iNumberOfThreads });
    foreach (JsonPDFReader.File items in F.files)
    {
        getData.Post(items);
    }
    getData.Complete();
    getData.Completion.Wait();
