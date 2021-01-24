    string url = ""; //Set url here
    
    using (HttpClient client = new HttpClient())
    {                
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
    
        var content = await client.GetStringAsync(url);
        return JsonConvert.DeserializeObject<Object>(content);
    }
