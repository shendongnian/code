    HttpContext oc = HttpContext.Current;
    IDictionaryEnumerator en = oc.Cache.GetEnumerator();
    while(en.MoveNext())
    {
        oc.Response.Write(en.Key.ToString());
    }
