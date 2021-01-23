    try
    {
        HtmlWeb webGet = new HtmlWeb();
        HtmlDocument document = webGet.Load(dealsiteLink); 
    }
    catch (WebException ex)
    {
        // Logic to cancel and retry (maybe in 10 minutes) goes here
    }
