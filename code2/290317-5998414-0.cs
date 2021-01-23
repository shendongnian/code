    string queryString = (new Uri("...")).Query;
    NameValueCollection parameters = HttpUtility.ParseQueryString(queryString);
    parameters.Get("filename");
    parameters.Get("employeeid");
    parameters.Get("age");
