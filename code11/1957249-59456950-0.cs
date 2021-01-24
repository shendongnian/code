    WebClient client = new WebClient();
    string uri = "API_URI";
    string json = "{some:\"json data\"}";
    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
    client.Headers.Add("Authorization", "apikey");
    string response = client.UploadString(uri,json);
