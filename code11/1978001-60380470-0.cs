    private async Task<Node> GetContent (string url)
    {
        var response = await _httpClient.GetAsync(url).Result;
        //**IMPORTANT** Ensure the stream is closed
        using(var stream= await response.Content.ReadAsStreamAsync())
        {
           var ser = new XmlSerializer(typeof(Node));
           var retVal = (Node)ser.Deserialize(stream);
           return retVal;
        }
    }
