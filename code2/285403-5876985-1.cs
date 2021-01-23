    HtmlWeb webGet = new HtmlWeb();
    HtmlDocument document;
    try
    {
        document = webGet.Load(dealsiteLink); 
    }
    catch (WebException ex)
    {
        // Logic to retry (maybe in 10 minutes) goes here
    }
