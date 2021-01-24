    static readonly HttpClient client = new HttpClient();
    private static void Main()
    {
        while (!Console.KeyAvailable)
        {
            PingWebsite("http://www.google.com/");
            Thread.Sleep(500);
        }
    }
    private static async void PingWebsite(string site)
    {
        Console.WriteLine("Pinging...");
        try
        {
            HttpResponseMessage response = await client.GetAsync(site);
            response.EnsureSuccessStatusCode();
            Console.WriteLine($"Status: {(int) response.StatusCode} {response.ReasonPhrase}");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"\nException Caught!\nMessage: {e.Message}");
        }
    }
