    String resonse = String.Empty;
    HttpClient client = new HttpClient();
    using (HttpResponseMessage httpResponse = client.Get("your_uri"))
    {
       response = httpResponse.Content.ReadAsString();
    }
