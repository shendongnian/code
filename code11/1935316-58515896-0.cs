    var siteUrl = "http://www.example.com/";
    var listName = "MySharePointList";
    var uri = new Uri(siteUrl);
    var credential = new NetworkCredential("username", "password", "domain");
    var credentialsCache = new CredentialCache { { uri, "NTLM", credential } };
    var handler = new HttpClientHandler { Credentials = credentialsCache };
    HttpClient client = new HttpClient(handler);
    
    client.BaseAddress = new Uri(uri, "/_vti_bin/ListData.svc");       
    client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
    client.DefaultRequestHeaders.Add("ContentType", "application/json;odata=verbose");
    var requestURL = siteUrl + "/_vti_bin/ListData.svc/" + listName;
    // Make the list request
    var result = client.GetAsync(requestURL).Result;
    var items= result.Content.ReadAsStringAsync();
