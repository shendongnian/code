    public List<BroadCategory> GetBroadCategories()
    {
        var results = Client.Get(string.Format(GraphBaseUri, AdAccount, AccessToken));
        var graphResult = JsonConvert.DeserializeObject<GraphResponse<BroadCategory>>(results.ToString());
        return graphResult.Data.ToList();
    } 
