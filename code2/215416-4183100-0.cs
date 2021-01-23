    private static string GetWebTest1(string url)        
    {            
         System.Net.WebClient Client = new WebClient();            
         return Client.DownloadString(url);        
    }
