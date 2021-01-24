    public static HtmlNode GetNodeById(HttpClient client, string url, string divId)
    {
        string pageHtml = "";
        using (HttpResponseMessage response = client.GetAsync(url).Result)
        {
            using (HttpContent content = response.Content)
            {
                pageHtml =  content.ReadAsStringAsync().Result;
            }
        }
    
        var doc = new HtmlDocument();
        doc.LoadHtml(pageHtml);
        HtmlNode node = doc.GetElementbyId(divId);
        return node;
    }
