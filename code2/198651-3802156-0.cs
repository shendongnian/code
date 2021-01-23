    System.Web.Caching.Cache cache = Page.Cache;
    List<KeyValuePair<string, object>> controlSetup;
    controlSetup = cache.Get("ControlSetup" + this.Id.ToString());
    if (controlSetup == null)
    {
        // Create the control setup from scratch
        // Put the created control setup into the cache
        cache.Put("ControlSetup" + this.Id.ToString(), controlSetup);
    }
    foreach (KeyValuePair(string, object) item In controlSetup
    {
        // Set the control values
    }
