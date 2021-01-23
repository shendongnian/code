    private void GetClaimParams(string targetUrl, out string loginUrl, out Uri navigationEndUrl)
            {
    HttpWebRequest webRequest = null;
                WebResponse response = null;
                webRequest = (HttpWebRequest)WebRequest.Create(targetUrl);
                webRequest.Method = Constants.WR_METHOD_OPTIONS;
                #if DEBUG
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(IgnoreCertificateErrorHandler);
                #endif
                try
                {
                    response = (WebResponse)webRequest.GetResponse();
                    ExtraHeadersFromResponse(response, out loginUrl, out navigationEndUrl);
                }
                catch (WebException webEx)
                {
                    ExtraHeadersFromResponse(webEx.Response, out loginUrl, out navigationEndUrl);
                }
    }
    
    
    
    #if DEBUG
            private bool IgnoreCertificateErrorHandler
               (object sender,
               System.Security.Cryptography.X509Certificates.X509Certificate certificate,
               System.Security.Cryptography.X509Certificates.X509Chain chain,
               System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            }
    #endif // DEBUG
