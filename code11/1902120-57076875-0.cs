    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("http://localhost:64195/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
