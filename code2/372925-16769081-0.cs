    public int SetSite(object site)
    {
       if (site != null)
       {
          webBrowser = (WebBrowser)site;
          webBrowser.DownloadComplete += new DWebBrowserEvents2_DownloadCompleteEventHandler(DownloadComplete);
          webBrowser.DownloadBegin += new DWebBrowserEvents2_DownloadBeginEventHandler(DownloadBegin);
       }
       else
       {
          webBrowser.DownloadComplete += new DWebBrowserEvents2_DownloadCompleteEventHandler(DownloadComplete);
          webBrowser.DownloadBegin += new DWebBrowserEvents2_DownloadBeginEventHandler(DownloadBegin);
          webBrowser = null;
       }
       return 0;
    }
