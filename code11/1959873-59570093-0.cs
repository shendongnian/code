    public async Task<IEnumerable<Dto>> GetDataInParallelWithBatches(IEnumerable<int> ids) 
    {
        var tasks = new List<Task<Dto>>();
        var batchSize = 200;
        int batchCount = (int) Math.Ceiling((double)ids.Count() / batchSize);
        for(int i = 0; i < batchCount; i++) 
        {
            var currentIds = ids.Skip(i * batchSize).Take(batchSize);
            tasks.Add(client.GetData(currentIds));
        }
    
        return (await Task.WhenAll(tasks)).SelectMany(d => d);
    }
