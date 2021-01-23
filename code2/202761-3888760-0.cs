    public object GetData (string colName) {
      NorthwindDataContext db = new NorthwindDataContext();
      var q = db.Products.Select(colName);
      List<object> list = new List<object>();
      foreach (var element in q) {
        if (!list.Contains(element))
          list.Add(element);
      }
      return list;</code></pre>
