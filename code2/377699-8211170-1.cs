    HttpContext oc = HttpContext.Current;
    foreach (var c in oc.Cache)        
    {
       oc.Response.Write(((DictionaryEntry)c).Key.ToString());
    }
