    try
        {
            request = this.m_WebRequest = this.GetWebRequest(this.GetUri(address));
            Stream responseStream = (this.m_WebResponse = this.GetWebResponse(request)).GetResponseStream();
            if (Logging.On)
            {
                Logging.Exit(Logging.Web, this, "OpenRead", responseStream);
            }
            stream2 = responseStream;
        }
        catch (Exception exception)
        {
         //
