    /// ---- ScreenScrape --------------------------------
    ///
    /// <summary>
    /// Input: URL like  "http://www.microsoft.com"
    /// Return: HTML string of site
    /// </summary>
    static public String ScreenScrape(String URL)
    {
        WebRequest TheRequest = WebRequest.Create(URL);
        WebResponse TheResponse = TheRequest.GetResponse();
        StreamReader TheStreamReader = new StreamReader(TheResponse.GetResponseStream(), Encoding.UTF8);
        String HTML = TheStreamReader.ReadToEnd();
        return HTML;
    }
