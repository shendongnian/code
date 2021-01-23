    static void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        WebClient webClient = new WebClient();
        string siteURL = (string)e.Argument;
        try
        {
            string sitePrefix = siteURL.Substring(0, 7);
            if(sitePrefix != "http://")
                siteURL = "http://" + siteURL;
        }
        catch
        {
            siteURL = "http://" + siteURL;
        }
        try
        {
            e.Result = webClient.DownloadString(siteURL);
        }
        catch
        {
            e.Result = "404";
        }
    }
