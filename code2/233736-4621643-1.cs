    public static IDictionary<string, string> ToDictionary(this NameValueCollection col)
    {
      var dict = new Dictionary<string, string>();
      
      foreach (var key in col.Keys)
      {
        dict.Add(key, col[key]);
      }
      
      return dict;
    }
