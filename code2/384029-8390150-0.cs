    public static void GoogleGeoCode(string address)
    {
        string url = "http://maps.googleapis.com/maps/api/geocode/json?sensor=true&address=";
        dynamic googleResults = new Uri(url + address).GetDynamicJsonObject();
        foreach (var result in googleResults.results)
        {
            Console.WriteLine("[" + result.geometry.location.lat + "," + 
                                    result.geometry.location.lng + "] " + 
                                    result.formatted_address);
        }
    }
    public static void GoogleSearch(string keyword)
    {
        string url = "http://ajax.googleapis.com/ajax/services/search/web?v=1.0&rsz=8&q=";
        dynamic googleResults = new Uri(url + keyword).GetDynamicJsonObject();
        foreach (var result in googleResults.responseData.results)
        {
            Console.WriteLine(
                result.titleNoFormatting + "\n" + 
                result.content + "\n" + 
                result.unescapedUrl + "\n");
        }
    }
    public static void Twitter(string screenName)
    {
        string url = "https://api.twitter.com/1/users/lookup.json?screen_name=" + screenName;
        dynamic result = new Uri(url).GetDynamicJsonObject();
        foreach (var entry in result)
        {
            Console.WriteLine(entry.name + " " + entry.status.created_at);
        }
    }
    public static void Wikipedia(string query)
    {
        string url = "http://en.wikipedia.org/w/api.php?action=opensearch&search=" + query +"&format=json";
        dynamic result = new Uri(url).GetDynamicJsonObject();
        Console.WriteLine("QUESTION: " + result[0]);
        foreach (var entry in result[1])
        {
            Console.WriteLine("ANSWER: " + entry);
        }
    }
