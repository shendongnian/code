    public static Attribute[] CreateAttributes(this DataRow row)
    {
      var attributes = new List<Attribute>();
      foreach (var item in Map)
      {
        attributes.AddRange(item.GetAttributes(row); 
      }
      return attributes.ToArray();
    }
