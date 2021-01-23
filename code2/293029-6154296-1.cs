    public SiteDetailViewModel(string subdomain) : this()
    {
       SiteStats.GetSiteStatistics(subdomain, "apiKeyHere", (result)=> {
         // Note you may need to wrap this in a Dispatcher call 
         // as you may be on the wrong thread to update the UI 
         // if that happens you'll get a cross thread access 
         // you will have to expose the dispatcher through some 
         // other mechanism. One way to do that would be a static
         // on your application class which we'll emulate and 
         // I'll give you the code in a sec
         myRootNamespace.App.Dispatcher.BeginInvoke(()=>this._siteStats = results);
       });
    }
