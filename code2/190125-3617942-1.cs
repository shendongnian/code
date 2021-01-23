    XDocument x = (XDocument)HttpContext.Current.Cache[ns + "SomeRandomDate"];
    if (x == null)
    {
      x = new XDocument(new XElement(ns + "SomeRandomDate", DateTime.Now()));
      HttpContext.Current.Cache.Insert(ns + "SomeRandomDate", x, null,
        DateTime.Now.AddHours(12d), Cache.NoSlidingExpiration);
    }
