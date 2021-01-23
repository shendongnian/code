    class MyWebClient : WebClient
    {
        public int StartDownloadAt { get; set; }
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest req = (HttpWebRequest)base.GetWebRequest(address);
    
            req.AddRange(position_to_start);
        }
    }
