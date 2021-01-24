        RestClient client;
        public API()
        {
            client = new RestClient("https://127.0.0.1:40/");
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            var certFile = "lxd.pfx";
            X509Certificate2 cert = new X509Certificate2(certFile, "(password)");
            client.ClientCertificates = new X509CertificateCollection() { cert };
            client.Proxy = new WebProxy();
        }
        public void Test()
        {
            var restrequest = new RestRequest("1.0/networks", Method.GET);
            IRestResponse response = client.Execute(restrequest);
            Logging.Log(response.Content, "API", LogLevel.INFO);
        }
