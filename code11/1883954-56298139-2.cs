    var tasks = Enumerable.Range(1, 10000)
        .Select(v => HttpClientFactory.Create().SendAsync(new HttpRequestMessage(HttpMethod.Put, new Uri($"http://example.com/books/1234/readers/837"))
        {
            Headers =
            {
                {"Header1", "Value1"},
                {"Header2", "Value2"},
                {"Header3", v.ToString()},
            },
            Content = new StringContent("{test:\"hello\"}", Encoding.UTF8, "application/json")
        }));
    
    var responses = await Task.WhenAll(tasks).ConfigureAwait(false);
    // ..
