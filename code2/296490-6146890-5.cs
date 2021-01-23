     public class RankedPage
        {
            public int Rank { get; set; }
            public string Site { get; set; }
        }
    
        public class WebRequestData
        {
            public WebRequest WebRequest { get; set; }
            public RankedPage Page { get; set; }
        }
    
        public class Scraper
        {
            private readonly IEnumerable<RankedPage> _sites;
            private readonly ConcurrentBag<KeyValuePair<RankedPage,string>> _data;
            private volatile int _count;
            private readonly int _total;
            public Scraper(IEnumerable<RankedPage> sites)
            {
                _sites = sites;
                _data = new ConcurrentBag<KeyValuePair<RankedPage, string>>();
                _total = sites.Count();
            }
    
            public void Start()
            {
                foreach (var site in _sites)
                {
                    ScrapeSite(site);
                }
            }
    
            private void ScrapeSite(RankedPage site)
            {
                var req = WebRequest.Create(site.Site);
                req.BeginGetResponse(AsyncCallback, new WebRequestData{ Page = site, WebRequest = req});
            }
    
            private void AsyncCallback(IAsyncResult ar)
            {
                Interlocked.Increment(ref _count);
                var webRequestData = ar.AsyncState as WebRequestData;
    
                var req = webRequestData.WebRequest;
                var result = req.EndGetResponse(ar);
                var reader = new StreamReader(result.GetResponseStream());
                var data = reader.ReadToEnd();
                this.OnSiteScraped(webRequestData.Page, data);
                _data.Add(new KeyValuePair<RankedPage, string>(webRequestData.Page,data));
                if (_count == _total)
                {
                    OnScrapingComplete();
                }
            }
    
            private void OnSiteScraped(RankedPage page, string data)
            {
                var handler = this.SiteScraped;
                if (handler != null)
                {
                    handler(this, new SiteScrapedEventArgs(page, data));
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
            public RankedPage Site { get; private set; }
            public string Data { get; private set; }
            public SiteScrapedEventArgs(RankedPage site, string data)
            {
                this.Site = site;
                this.Data = data;
            }
        }
    
        public class ScrapingCompletedEventArgs : EventArgs
        {
            public IEnumerable<KeyValuePair<RankedPage,string >> SiteData { get; private set; }
            public ScrapingCompletedEventArgs(IEnumerable<KeyValuePair<RankedPage, string>> siteData)
            {
                this.SiteData = siteData;
            }
        }
