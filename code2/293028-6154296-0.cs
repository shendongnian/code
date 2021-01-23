    public class SiteStats
    {
      public string seller_name { get; set;}
      public static void GetSiteStatistics(string subdomain, string apiKey, Action<SiteStats> callback)
      {
        SiteStats retVal = null;
        HttpWebRequest request = WebRequest.Create(string.Format("https://{0}.chargify.com/stats.json", subdomain)) as HttpWebRequest;
        NetworkCredential credentials = new NetworkCredential(apiKey, "X");
        request.Credentials = credentials;
        request.Method = "GET";
        request.Accept = "application/json";
        request.BeginGetResponse(result =>
        {
            using (var response = request.EndGetResponse(result))
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string stats = reader.ReadToEnd();
                    retVal = Json.Deserialize<SiteStats>(stats);
                    callback(retVal);
                }
            }
        }, request);
        //return retVal; // you can't return here
      }
    }
