       [ServiceContract]
       public interface INewsFeed
       {
          [OperationContract]
          [WebGet]
          Atom10FeedFormatter GetFeeds();
       }
        public class NewsFeed : INewsFeed
        {
              public Atom10FeedFormatter GetFeeds()
              {
              SyndicationFeed feed = new SyndicationFeed("My Blog Feed", "This is a test feed", new Uri("http://SomeURI"));
               feed.Authors.Add(new SyndicationPerson("someone@microsoft.com"));
               feed.Categories.Add(new SyndicationCategory("How To Sample Code"));
               feed.Description = new TextSyndicationContent("This is a how to sample that demonstrates how to expose a feed using RSS with WCF");
    
              SyndicationItem item1 = new SyndicationItem(
                 "Lorem ipsum",
                 "Lorem ipsum",
                 new Uri("http://localhost/Content/One"),
                 "ItemOneID",
                 DateTime.Now);
             List<SyndicationItem> items = new List<SyndicationItem>();  
             items.Add(item1); 
             feed.Items = items;   
             return new Atom10FeedFormatter(feed);
              }
        }
