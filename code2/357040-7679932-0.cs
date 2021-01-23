    XmlDocument xDoc = new XmlDocument(); 
     
    if (Cache.Get("MenuData") == null) 
    { 
        xDoc.Load(Server.MapPath("/MenuData.xml")); 
        Cache.Insert("SiteNav", xDoc, new CacheDependency(Server.MapPath("/MenuData.xml"))); 
    } 
    else 
    { 
        xDoc = (XmlDocument)HttpContext.Current.Cache.Get("MenuData"); 
    } 
