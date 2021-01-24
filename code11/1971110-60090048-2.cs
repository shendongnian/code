    HttpClient client = new HttpClient();
    byte[] authBytes = System.Text.Encoding.ASCII.GetBytes("mucode:mypassword");
    string base64Auth = Convert.ToBase64String(authBytes);
    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Auth);
            
    HttpContent content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("grant_type", "client_credentials") });
    var response = client.PostAsync(new Uri("https://api.sandbox.paypal.com/v1/oauth2/token"), content).Result;
    if (response.IsSuccessStatusCode)
    {
        var responseContent = response.Content;
        string responseString = responseContent.ReadAsStringAsync().Result;
        Console.WriteLine(responseString);
    }
