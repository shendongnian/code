    private bool WebsiteUp(string uri)
    {
        try
        {
            WebRequest request = WebRequest.Create(uri);
            request.Timeout = 3000;
            request.Method = "HEAD";
            using(WebResponse response = request.GetResponse())
            {
                HttpWebResponse hRes = response as HttpWebResponse;
                if(hRes == null)
                    throw new ArgumentException("Not an HTTP or HTTPS request"); // you may want to have this specifically handle e.g. FTP, but I'm just throwing an exception for now.
                return hRes.StatusCode / 100 == 2;
            }
        }
        catch (WebException) 
        {
            return false;
        }
    }
