    static async Task Main(string[] args)
    {
        Console.WriteLine("1");
        Task<string> statusCodeRunning = PreprocessingAsync();
        for (int i = 0; i <= 100; i++)
        {
            Console.Write("+++");
        }
        string statusCodeFinshed = await statusCodeRunning;
        Console.WriteLine(statusCodeFinshed);
        Console.ReadLine();
    }
    private static async Task<string> PreprocessingAsync()
    {
        try
        {
            Console.WriteLine("2");
            HttpClient httpClient = new HttpClient();
            string message = await httpClient.GetStringAsync("http://www.baidu.com/");
            return message;
        }
        catch (HttpRequestException)
        {
            Console.WriteLine("Catch");
            throw;
        }
    }
