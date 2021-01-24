    void Main()
    {
        await InitClient();
        // Pass the file title to the API
        var result = await GetFilmAsync("it");
        client.CancelPendingRequests();
        client.Dispose();    
    }
    // Changed name to be more meaningful 
    static async Task InitClient()
    {
        // Remove the part with your key and the film title from the general initialization
        client.BaseAddress = new Uri("http://www.omdbapi.com/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    
    }
    
    static async Task<Film> GetFilmAsync(string title)
    {
        Film film = null;
        // Compose the path adding the key and the film title
        string path = "?apikey=caa4fbc9&t=" + title;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            // This is the key point, the API returns a JSON string
            // You need to convert it to your Film object.
            // In this example I have used the very useful JSon.NET library
            // that you can easily install with NuGet.
            film = JsonConvert.DeserializeObject<Film>(data);
        }
        return film;
    }
