public static async Task MainAsync()
{
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://localhost:1234");
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("", "Joe Bloggs")
        });
        var result = await client.PostAsync("/api/Customer/exists", new StringContent(content.ToString(), Encoding.UTF8, "application/json"));
        string resultContent = await result.Content.ReadAsStringAsync();
        Console.WriteLine(resultContent);
    }
}
