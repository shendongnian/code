    HttpContext oc = HttpContext.Current;
    foreach (var c in oc.Cache)        
    {
       oc.Response.Write(((System.Collections.DictionaryEntry)(c)).Key.ToString());
    }
