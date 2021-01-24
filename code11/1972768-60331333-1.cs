    private HttpClient CreateHttpClient()
            {
                var client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    
                string baseAddress = WebApiBaseAddress;
                if (string.IsNullOrEmpty(baseAddress))
                {
                    throw new HttpRequestException("There is no base address specified in the configuration file.");
                }
                client.Timeout = new TimeSpan(0, 5, 59);
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", _cred.eBayToken));
                client.DefaultRequestHeaders.Add("Accept-Language", "en-US");
                client.DefaultRequestHeaders.Add("Accept-Charset", "utf-8");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("LegacyUse", "true");
                return client;
            }
