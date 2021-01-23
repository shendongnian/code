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
            _data.Add(reader.ReadToEnd());
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
