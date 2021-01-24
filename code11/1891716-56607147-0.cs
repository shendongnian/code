    private static async Task Go()
    {
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        Client.DefaultRequestHeaders.ConnectionClose = true;
        var tasks = Tags.Select(tag =>
        {
            var requests = new List<Task>();
            for (int i = 1; i < 4; i++)
            {
                switch (i)
                {
                    case 1:
                        prefix = "1";
                        break;
                    case 2:
                        prefix = "2";
                        break;
                    case 3:
                        prefix = "3";
                        break;
                }
                requests.Add(MakeRequest(Client, prefix, tag));
            }
            return requests;
        }).SelectMany(t => t);
        await Task.WhenAll(tasks);
    }
    private async static Task MakeRequest(HttpClient client, string prefix, string tag)
    {
        
        using (var response = await client.GetAsync("https://example.com/" + prefix, HttpCompletionOption.ResponseHeadersRead))
        {
            Console.WriteLine(tag + " and " + prefix);
            Console.WriteLine(prefix + " and " + (int)response.StatusCode);
        }
    }
