    private CookieContainer cookieContainer = new CookieContainer();
    public bool isServerOnline()
    {
            Boolean ret = false;
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(VPMacro.MacroUploader.SERVER_URL);
                req.CookieContainer = cookieContainer; // <= HERE
                req.Method = "HEAD";
                req.KeepAlive = false;
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    // HTTP = 200 - Internet connection available, server online
                    ret = true;
                }
                resp.Close();
                return ret;
            }
            catch (WebException we)
            {
                // Exception - connection not available
                Log.e("InternetUtils - isServerOnline - " + we.Status);
                return false;
            }
    }
