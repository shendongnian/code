    string newParamName = "QueryParam";
    string newParamValue = HttpUtility.UrlEncode(Request.QueryString("queryValue").ToString());
    Uri uri = HttpContext.Current.Request.Url;
    string url = uri.Scheme + "://" + "www.otherdomain.com" + "/Files/TheFileRequest.aspx" + "?" + newParamName + "=" + newParamValue;
    HttpContext.Current.Response.Redirect(url);
