    //setup reusable http client
    HttpClient client = new HttpClient();
    Uri baseUri = new Uri(url);
    client.BaseAddress = baseUri;
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.ConnectionClose = true;
    
    //Post body content
    var values = new List<KeyValuePair<string, string>>();
    values.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
    var content = new FormUrlEncodedContent(values);
    
    var authenticationString = $"{clientId}:{clientSecret}";
    var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
    
    var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/oauth2/token");
    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
    requestMessage.Content = content;
    
    //make the request
    var task = client.SendAsync(requestMessage);
    var response = task.Result;
    response.EnsureSuccessStatusCode();
    string responseBody = response.Content.ReadAsStringAsync().Result;
    Console.WriteLine(responseBody);
