     public List<HistoryRequest> GetHistoryRequestList()
        {
            Configuration roamingConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string OSBBaseUri = ConfigurationManager.AppSettings["OSBUrl"];
            string OSBGetEndPoint = ConfigurationManager.AppSettings["OSBEndPoint"];
            string MSDCallerId = ConfigurationManager.AppSettings["AppId"];
            string Encoding = "iso-8859-1";
            string Osbpw = HistoryCrypto.Decrypt(ConfigurationManager.AppSettings["CipherPass"], ConfigurationManager.AppSettings["CryptoKey"]);
            CredentialCache credentialCache = new CredentialCache
            {
                {
                    new Uri(OSBBaseUri),
                    "NTLM",
                    new NetworkCredential()
                    {
                        UserName = "<UserName>",
                        Password = Osbpw,
                        Domain = ConfigurationManager.AppSettings["Domain"]
                    }
                }
            };
            HttpMessageHandler handler = new HttpClientHandler()
            {
                Credentials = credentialCache
            };
            var _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(OSBBaseUri),
                Timeout = new TimeSpan(0, 2, 0),
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("HTTP_Referrer/HistoryRequestProcess"));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("MSCRMCallerID/"+ MSDCallerId));
            HttpContent httpContent = new StringContent("{\"operationssubtypecode\":\"HREQ\"} ", System.Text.Encoding.UTF8, "application/json");
            var method = new HttpMethod("GET");
            var message = new HttpRequestMessage(method, OSBGetEndPoint)
            {
                Content = httpContent
            };
            message.Headers.Add("HTTP_Referrer", "HistoryRequestProcess");
            message.Headers.Add("MSCRMCallerID", MSDCallerId);
            HttpResponseMessage response = _httpClient.GetAsync(OSBGetEndPoint).Result;
            string content = string.Empty;
            using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, System.Text.Encoding.GetEncoding(Encoding)))
            {
                content = stream.ReadToEnd();
            }
            return LoadHistoryRequest(content);
        }
