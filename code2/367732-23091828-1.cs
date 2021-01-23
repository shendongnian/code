    using System;
    using System.Configuration;
    using System.Web;
    
    namespace CSASPNETResumeDownload
    {
        public class DownloadHttpHandler : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                string filePath = ConfigurationManager.AppSettings["FilePath"];
                Downloader.DownloadFile(context, filePath);
            }
    
            public bool IsReusable
            {
                get { return false; }
            }
        }
    }
