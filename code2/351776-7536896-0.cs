    class HttpClient
    {
        private volatile bool _httpClientConnected;
        //.. initialize in constructor
    
        public string GetHtmlCode(string url)
        {
            string html = string.Empty;
            if(_httpClientConnected)
            {
                html = FetchPage(url);
            }
            return html;
        }
        
        public void Connect()
        {
            _httpClientConnected = true;
            ConnectClient();
        }
    
        public void Disconnect()
        {
            _httpClientConnected = false;
            DisconnectClient();
        }
    }
