    System.Collections.Specialized.NameValueCollection myform = Request.Form; 
    IDictionary<string, string> myDictionary = 
        myform.Cast<string>()
        .Select(s => new { Key = s, Value = myform[s] })
        .ToDictionary(p => p.Key, p => p.Value);
