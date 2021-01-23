    try 
    {
      	WebClient client = new WebClient();
        byte[] pageData = client.DownloadData("http://www.contoso.com");
        string pageHtml = Encoding.ASCII.GetString(pageData);
        Console.WriteLine(pageHtml);
        client.DownloadFile("http://www.contoso.com", "page.htm");
    }
    catch (WebException webEx) 
    {
        Console.WriteLine(webEx.ToString());
        if(webEx.Status == WebExceptionStatus.ConnectFailure) 
        {
            Console.WriteLine("Are you behind a firewall?  If so, go through the proxy server.");
        }
    }
