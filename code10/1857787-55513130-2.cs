    public static async Task<BingMapsRESTToolkit.Location> ExecuteQuery(string queryText)
    {
        //Create a request.
        var request = new GeocodeRequest()
            {
                Query = queryText,
                MaxResults = 1,
                BingMapsKey = ApiKey
        };
        //Process the request by using the ServiceManager.
        var response = await request.Execute();
        if (response != null &&
                response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
        {
             return response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;
        }
        return null;
    }
