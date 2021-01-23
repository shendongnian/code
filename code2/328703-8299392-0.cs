    [WebGet(ResponseFormat = WebMessageFormat.Json)]
    public bool ConfigurationChanged(string jsonStr)
    {
        try
        {
            MyObject obj = new JavaScriptSerializer().Deserialize<MyObject>(jsonStr);
            
            // ... do something with MyObject
        }
        catch (Exception)
        {
            throw;
        }
    }
