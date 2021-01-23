    class Information
    {
      public string UserName { get { return this.GetFromSession("UserName"); } }
      public string WebSiteName { get { return this.GetFromCache("WebSiteName"); } }
    
      private string GetFromSession(string key)
      { /* get information from session */ }
    
      private string GetFromCache(string key)
      { /* get information from cache */}
    }
