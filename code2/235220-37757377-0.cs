    using System;
    using System.Net;
    
    namespace MutualFund
    {
        internal class CustomWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);
                if (request is HttpWebRequest)
                {
                    (request as HttpWebRequest).KeepAlive = false;
                }
                return request;
            }
        }
    }
