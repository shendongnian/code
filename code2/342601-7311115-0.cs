    public interface IResultsStrategy {
        RateResults GetRateResults(SiteInfo site);
    }
    
    public class SpecificSiteStrategy {
        public RateResults GetRateResults(SiteInfo site) {
            //access the service through WCF, or whatever makes the most sense
            //create a new RateResults object, and fill it with the appropriate data
        }
    }
    
    public class AnotherSiteStrategy {
        public RateResults GetRateResults(SiteInfo site) {
            //access the service through a web request, or whatever makes the most sense
            //create a new RateResults object, and fill it with the appropriate data
        }
    }
    
    public class RateFetcher {
        public IEnumerable<RateResults> GetRates() {
            var rateResults = new List<RateResults();
            foreach(SiteInfo site in SitesToFetch) {
                IResultsStrategy strategy = GetStrategy(site);
                rateResults.Add(strategy.GetRateResults(site));
            }
            return rateResults;
        }
    }
