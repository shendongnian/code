    foreach(Object item in _area) {
      
      System.Reflection.PropertyInfo pi = item.GetType().GetProperty("name");
      String yourValue = (String)(pi.GetValue(item, null));
    }
