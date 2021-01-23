    private bool Ping(string url)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Timeout = 3000;
            request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
            request.Method = "HEAD";
        
            using (var response = request.GetResponse())
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
