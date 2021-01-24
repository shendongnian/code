    private List<string> _UidResponses = new List<string>();
    HttpClient _client = new HttpClient();
    private Task GetResponseAsync(int iPage = 1)
    {
        try
        {
            NameValueCollection nameValues = HttpUtility.ParseQueryString(String.Empty);
            nameValues.Add("uid", _BarcodeUid);
            nameValues.Add("page", iPage.ToString());
            var newUrl = _ServiceURL + nameValues;
    
            client.BaseAddress = new Uri(newUrl);
    
            var result = await client.PostAsync(newUrl, new StringContent(""));
    
            if (result.IsSuccessStatusCode)
            {
               [...]
            }
        }
        catch (Exception err)
        { }
    
    }
