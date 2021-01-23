    public class ScraperBase
    {
        // Common methods for making web requests, etc.
        // When you want to download and scrape a page, you call this:
        public List<string> DownloadAndScrape(string url)
        {
            // make request and download page.
            // Then call Scrape ...
            return Scrape(pageText);
        }
        // And an abstract Scrape method that returns a List<string>
        // Inheritors implement this method.
        public abstract List<string> Scrape(string pageText);
    }
