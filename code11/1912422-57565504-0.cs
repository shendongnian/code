    public static HttpClientHandler httpClientHandler = new HttpClientHandler()
    private static HttpClient Client1 = new HttpClient(handler: httpClientHandler, disposeHandler: true) { MaxResponseContentBufferSize = 10000000 };`
    private static HttpClient Client2 = new HttpClient(handler: httpClientHandler, disposeHandler: true) { MaxResponseContentBufferSize = 10000000 };`
    private static HttpClient Client3 = new HttpClient(handler: httpClientHandler, disposeHandler: true) { MaxResponseContentBufferSize = 10000000 };`
    private static HttpClient Client4 = new HttpClient(handler: httpClientHandler, disposeHandler: true) { MaxResponseContentBufferSize = 10000000 };
    private Button1_Click(Object sender, EventArgs e)
    {
        httpClientHandler.Proxy = null;
        httpClientHandler.UseProxy = false;
        Task t1=Task.Run(()=>DoWork(dt1,Client1));
        Task t1=Task.Run(()=>DoWork(dt2,Client2));
        Task t1=Task.Run(()=>DoWork(dt3,Client3));
        Task t1=Task.Run(()=>DoWork(dt4,Client4));
        await Task.WhenAll(t1,t2,t3,t4);
    }
    public async Task DoWork(DataTable dt,HttpClient Client)
    {
        var allTasks = new List<Task>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if(Some condition)
            allTasks.Add(Task.Run(() => GetApiData(Client)));            
        }
        Task waitAll = Task.WhenAll(allTasks);
        await waitAll;
    }
    public async Task GetApiData(HttpClient Client)
    {
        var Result= await (await Client.GetAsync("Some Url")).Content.ReadAsStringAsync();
        //do some cpu bound(but not too heavy, like search in a datatable that have 20 rows) work on Result.
    }
