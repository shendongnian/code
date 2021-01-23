    public string getQueryStringValueOrEmpty(string key)
    {
      string result = HttpContext.Current.Request.QueryString[key];
      
      if(result == null)
      {
        result = string.Empty;
      }
    
      return result;
    }
