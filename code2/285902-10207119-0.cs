        public class BHO:IObjectWithSite
        {
            private WebBrowser webBrowser;
    
            public int SetSite(object site){
                    webBrowser = (WebBrowser)site;
                    webBrowser.DownloadComplete +=new DWebBrowserEvents2_DownloadCompleteEventHandler(webBrowser_DownloadComplete);
           (...)
       }
