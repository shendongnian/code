    String UserIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
    if (string.IsNullOrEmpty(UserIP))
    {
        UserIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
    }
    string url = "http://freegeoip.net/json/" + UserIP.ToString();
    WebClient client = new WebClient();
    string jsonstring = client.DownloadString(url);
    dynamic dynObj = JsonConvert.DeserializeObject(jsonstring);
    System.Web.HttpContext.Current.Session["UserCountryCode"] = dynObj.country_code;
