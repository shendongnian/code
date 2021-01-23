    try
    {
      System.Net.WebRequest reqGoogle = System.Net.WebRequest.Create("http://www.google.com/webmasters/tools/ping?sitemap=" + HttpUtility.UrlEncode("http://www.shree/SiteMap/'" + PortalName + "'/sitemap.xml"));
      reqGoogle.GetResponse();
    }
    catch(WebException ex)
    {
      MessageBox.Show("Google is blocked");
    }
