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
               var _MSG = await result.Content.ReadAsStringAsync();
               JavaScriptSerializer jss = new JavaScriptSerializer();
               try
               {
                  if (!string.IsNullOrEmpty(_MSG))
                  {
                     List<string> objectItems = jss.Deserialize<List<string>>(_MSG);
                     _UidResponses.AddRange(objectItems);
                     if (objectItems.Count() >= _ItemCount)
                     {
                        GetResponse(++iPage);
                     }
                  }
               }
               catch (Exception rr)
               { }
    
            }
        }
        catch (Exception err)
        { }
    
    }
