Generate sitemap
   
     private void SubmitSitemap(string PortalName)
        {
            //PING SEARCH ENGINES TO LET THEM KNOW WE UPDATED OUR SITEMAP
    
            //resubmit to google
    
            System.Net.WebRequest reqGoogle = System.Net.WebRequest.Create("http://www.google.com/webmasters/tools/ping?sitemap=" + HttpUtility.UrlEncode("http://your path'" + PortalName + "'/sitemap.xml"));
            reqGoogle.GetResponse();
    
            //resubmit to ask
    
            System.Net.WebRequest reqAsk = System.Net.WebRequest.Create("http://submissions.ask.com/ping?sitemap=" + HttpUtility.UrlEncode("http://your path + "'/sitemap.xml"));
            reqAsk.GetResponse();
    
            //resubmit to yahoo
    
            System.Net.WebRequest reqYahoo = System.Net.WebRequest.Create("http://search.yahooapis.com/SiteExplorerService/V1/updateNotification?appid=YahooDemo&url=" + HttpUtility.UrlEncode("http://yourpath/sitemap.xml"));
            reqYahoo.GetResponse();
    
            //resubmit to bing
    
            System.Net.WebRequest reqBing = System.Net.WebRequest.Create("http://www.bing.com/webmaster/ping.aspx?siteMap=" + HttpUtility.UrlEncode("http://yourpath + "'/sitemap.xml"));
            reqBing.GetResponse();
    
        }
