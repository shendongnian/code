    public static RouteValueDictionary ToRouteDic(this NameValueCollection queryString)
    {
        if (queryString.IsNull() || queryString.HasKeys() == false) return new RouteValueDictionary();
        var routeValues = new RouteValueDictionary();
        foreach (string key in queryString.AllKeys)
            routeValues.Add(key, queryString[key]);
        return routeValues;
    }
