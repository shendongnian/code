    public delegate List<string> PageScraperDelegate(string pageText);
    public class PageScraper
    {
        public List<string> DownloadAndScrape(string url, PageScraperDelegate callback)
        {
            // download data to pageText;
            return callback(pageText);
        }
    }
