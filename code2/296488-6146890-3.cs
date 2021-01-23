    public class Scraper
    {
        private readonly IEnumerable<string> _sites;
        private readonly ConcurrentBag<string> _data;
        private volatile int _count;
        private readonly int _total;
        public Scraper(IEnumerable<string> sites)
        {
            _sites = sites;
            _data = new ConcurrentBag<string>();
            _total = sites.Count();
        }
        public void Start()
        {
            foreach (var site in _sites)
            {
                ScrapeSite(site);
            }
        }
        private void ScrapeSite(string site)
        {
            var req = WebRequest.Create(site);
            req.BeginGetResponse(AsyncCallback, req);
        }
        private void AsyncCallback(IAsyncResult ar)
        {
            Interlocked.Increment(ref _count);
            var req = ar.AsyncState as WebRequest;
            var result = req.EndGetResponse(ar);
            var reader = new StreamReader(result.GetResponseStream());
            var data = reader.ReadToEnd();
            this.OnSiteScraped(req.RequestUri.AbsoluteUri, data);
            _data.Add(data);
            if (_count == _total)
            {
                OnScrapingComplete();
            }
        }
        private void OnSiteScraped(string site, string data)
        {
            var handler = this.SiteScraped;
            if (handler != null)
            {
                handler(this, new SiteScrapedEventArgs(site, data));
            }
        }
        private void OnScrapingComplete()
        {
            var handler = this.ScrapingComplete;
            if (handler != null)
            {
                handler(this, new ScrapingCompletedEventArgs(_data));
            }
        }
        public event EventHandler<SiteScrapedEventArgs> SiteScraped;
        public event EventHandler<ScrapingCompletedEventArgs> ScrapingComplete;
    }
    public class SiteScrapedEventArgs : EventArgs
    {
        public string Site { get; private set; }
        public string Data { get; private set; }
        public SiteScrapedEventArgs(string site, string data)
        {
            this.Site = site;
            this.Data = data;
        }
    }
