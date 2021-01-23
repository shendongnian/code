    using WUApiLib;
    UpdateSession uSession = new UpdateSession();
    IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
    uSearcher.Online = false;
    try
    {
        ISearchResult sResult = uSearcher.Search(String.Empty);
        // This one!!!!
        var maxTime = sResult.Updates.OfType<IUpdate>().Max(p => p.LastDeploymentChangeTime);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Something went wrong: " + ex.Message);
    } 
