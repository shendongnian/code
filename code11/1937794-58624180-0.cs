    Console.WriteLine("**** Starting Synccentric API Fetch ****");
    var client = new RestClient("https://v3.synccentric.com/api/v3/products");
    var request = new RestRequest(Method.GET);
    
    Console.WriteLine("**** Adding Headers, Content Type & Auth Key ****");
    request.AddHeader("Content-Type", "application/json");
    request.AddHeader("Authorization", "Bearer {{MyAPIToken}}");
    
    Console.WriteLine("**** Adding parameters ****");
    request.AddParameter("campaign_id", 12618);
    request.AddParameter("downloadable", "true");
    request.AddParameter("downloadable_type", "CSV");
    
    var fields = new[] { "asin", "upc", "actor", "all_categories" };
    foreach (var field in fields)
    {
        request.AddParameter("fields", field);
    }
    
    IRestResponse response = client.Execute(request);
