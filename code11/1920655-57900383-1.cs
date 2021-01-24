 csharp
    async Task Main()
    {
        await BatchProcessAsync(GetValues(), ProcessElementAsync);
    }
    
    public async Task BatchProcessAsync<T>(IEnumerable<T> elements, Func<T, Task> operationAsync, int batchSize = 10)
    {
        var batchIndex = 0;
        var batch = GetNextBatch();
        while (batch.Any())
        {
            await Task.WhenAll(batch.Select(operationAsync));
            ++batchIndex;
            batch = GetNextBatch();
        }
    
        IEnumerable<T> GetNextBatch()
            => elements.Skip(batchIndex * batchSize).Take(batchSize);
    }
    
    public async Task ProcessElementAsync(string element)
    {
        Print($"Processing element: {element}...");
        await Task.Delay(300);
        Print($"Completed element: {element}.");
    
        void Print(string output)
            => Console.WriteLine($"[{DateTime.Now:s}] {output}");
    }
    
    public IEnumerable<string> GetValues(int maxValues = 100)
        => Enumerable.Range(1, maxValues).Select(i => $"Element #{i}");
**EDIT** After posting I re-read the original question and realize that this implementation assumes you have already read all the records and therefore misses on the part of having the main thread continuing reading records from the input file.  However, it should not be difficult to apply the same batching technique to reading the records from the input file in batches and then feeding the records in to be batch processed.
