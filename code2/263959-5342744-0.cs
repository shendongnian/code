    [WebGet(UriTemplate = "{part}")]
    public Distributor GetDistributorInventory(string part)
    {
      const string url = "http://www.site.com/service/lookup.asmx/StockCheck";
      string results = WebHelper.HttpRequest("POST", "application/json; charset=utf-8", "{part: " + part + "}", url, new CookieContainer());
    
      Inventory inventory = new JavaScriptSerializer().CleanAndDeserialize<Inventory>(results);
    
      return inventory;
    }
