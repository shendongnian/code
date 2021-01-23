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
            using (var client = new WebClient())
            {
                client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
                client.DownloadStringAsync(new Uri(site));
            }
        }
        private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Interlocked.Increment(ref _count);
            if (!String.IsNullOrEmpty(e.Result))
            {
                _data.Add(e.Result);
            }
            if (_count == _total)
            {
                OnScrapingComplete();
            }
        }
        private void OnScrapingComplete()
        {
            var handler = this.ScrapingComplete;
            if(handler != null)
            {
                handler(this, new ScrapingCompletedEventArgs(_data));
            }
        }
        public event EventHandler<ScrapingCompletedEventArgs> ScrapingComplete;
    }
    public class ScrapingCompletedEventArgs : EventArgs
    {
        public IEnumerable<string> SiteData { get; private set; }
        public ScrapingCompletedEventArgs(IEnumerable<string> siteData)
        {
            this.SiteData = siteData;
        }
    }
