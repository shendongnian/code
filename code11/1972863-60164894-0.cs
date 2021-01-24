    string url = "url";
    var client = new HttpClient();
    var checkingResponse = await client.GetAsync(url);
    if (checkingResponse.IsSuccessStatusCode) {
        Console.WriteLine($"{url} is alive");
    }
