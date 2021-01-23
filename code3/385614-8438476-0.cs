    public static string GetRealm(string url)
    {
        var request = (HttpWebRequest)WebRequest.Create(url);
        try
        {
            using (request.GetResponse())
            {
                return null;
            }
        }
        catch (WebException e)
        {
            if (e.Response == null) return null;
            var auth = e.Response.Headers[HttpResponseHeader.WwwAuthenticate];
            if (auth == null) return null;
            // Example auth value:
            // Basic realm="Some realm"
            return ...Extract the value of "realm" here (with a regex perhaps)...
        }
    }
