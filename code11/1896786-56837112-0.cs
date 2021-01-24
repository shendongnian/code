    public string MakeHelloWorldCallUsingHttpClient()
    {
        string requestURL = "https://sandbox.api.visa.com/vdp/helloworld";
        string userId = ConfigurationManager.AppSettings["userId"];
        string password = ConfigurationManager.AppSettings["password"];
        string apiResponse = "";
        HttpClientHandler clientHandler = new HttpClientHandler();
        
        HttpClient httpClient = new HttpClient(clientHandler);
        httpClient.DefaultRequestHeaders.Authorization 
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", GetBasicAuthHeaderValue(userId, password));
        try
        {
            // Make the call
            var response = httpClient.GetAsync(requestURL).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                apiResponse = response.Content.ReadAsStringAsync().Result;
            }
        }
        catch (WebException e)
        {
            Console.WriteLine(e.Message);
            Exception ex = e.InnerException;
            while (ex != null)
            {
                Console.WriteLine(ex.Message);
                ex = ex.InnerException;
            }
            if (e.Response is HttpWebResponse)
            {
                HttpWebResponse response = (HttpWebResponse)e.Response;
                apiResponse = response.StatusCode.ToString();
            }
        }
        return apiResponse;
    }
    private string GetBasicAuthHeaderValue(string userId, string password)
    {
        string authString = userId + ":" + password;
        var authStringBytes = Encoding.UTF8.GetBytes(authString);
        return Convert.ToBase64String(authStringBytes);
    }
