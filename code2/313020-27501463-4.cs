    public class TwitterTimelineRetriever
    {
    private readonly XDocument _twitterTimelineXml;  
    public TwitterTimelineRetriever()
    {
        _twitterTimelineXml = XDocument
            .Load("http://api.twitter.com/1/statuses/public_timeline.xml");
    }  
    public IEnumerable<ITweetContract> GetPublicTimeline(int numberOfTweets)
    {
        var tweets = _twitterTimelineXml.Descendants("status")
            .Take(numberOfTweets);  
        return tweets.Select(Mapper.Map<XElement, ITweetContract>).ToList();
    }
    }
