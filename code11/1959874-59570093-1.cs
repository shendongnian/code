    private static readonly HttpClient _client;
    
    public MyService() {
        _client = new HttpClient();
    }
    
    public async Task<IEnumerable<string>> PostData(string url) {
        var data = new StringContent("{}", Encoding.UTF8, "application/json");
       
        var response = await _client.PostAsync(url, data);
    
        string result = await response.Content.ReadAsStringAsync();
    
        return result;
    }
    
    public async Task<IEnumerable<string>> PostDataParallelBatch(IEnumerable<string> urls) 
    {
        var tasks = new List<Task<string>>();
        var batchSize = 100;
        int batchCount = (int) Math.Ceiling((double)urls.Count() / batchSize);
        for(int i = 0; i < batchCount; i++) 
        {
            var currentUrls = urls.Skip(i * batchSize).Take(batchSize);
            tasks.Add(GetData(currentUrls));
        }
    
        return (await Task.WhenAll(tasks)).SelectMany(d => d);
    }
