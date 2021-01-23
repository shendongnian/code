    interface Scraper
    {
        string DateToUrl(DateTime date);
    }
    
    class ScraperA: Scraper
    {
        string DateToUrl(DateTime date)
        {
            return "some string based on date";
        }
    }
