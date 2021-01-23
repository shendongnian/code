    public interface IScraper
    {
      string ScrapeDate(string url);
    }
    
    public abstract class Scraper : IScraper
    {
      public string ScrapeDate(string url)
      {
        // default implementation
      }
    }
