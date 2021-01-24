    [TestMethod]
    public void TestAutocomplete()
    {
        string resource = "api/addresses";
        List<AutocompleteSuggestions> suggests = GetAutocompleteSuggestions(resource).Result;
        Assert.AreEqual(1, suggests.Count);
    }
    async Task<List<AutocompleteSuggestions>> GetAutocompleteSuggestions(string path)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri("http://localhost:22292/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.GetAsync(path);
            List<AutocompleteSuggestions> suggests = null;
            if (response.IsSuccessStatusCode)
            {
                suggests = await response.Content.ReadAsAsync<List<AutocompleteSuggestions>>();
            }
            return suggests;
        }
    }
