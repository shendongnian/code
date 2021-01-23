    var pp = typeof(T).GetProperties().Where(p => p.Name == "Id").FirstOrDefault();
    if (pp != null)
    {
      if (pp.PropertyType.Name == "Int64" || pp.PropertyType.Name == "Int32")
      {
        Map();
      }
    }
