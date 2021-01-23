    using System;
    using System.Net;
    using System.ServiceModel;
    namespace Example
    {
        class MyApi
        {
            private const int _apiPortNumber = 8080;
            public const string BasePath = "/myApi/";
            public static EndpointAddress MyEndPoint => new EndpointAddress(
                new UriBuilder(
                        Uri.UriSchemeHttp,
                        "localhost",//only allow connections on localhost (no remote access)
                        _apiPortNumber,
                        BasePath)
                    .Uri);
            
            public MyApi()
            {
                var httpListener = new System.Net.HttpListener();
                httpListener.Prefixes.Add(MyEndPoint.Uri.ToString());
				httpListener.Start();
            }
        }
    }
