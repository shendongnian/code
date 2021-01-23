    public ActionResult Feed()
    {
        var feed = new SyndicationFeed(
            "Test Feed",
            "This is a test feed",
            new Uri("http://Contoso/testfeed"),
            "TestFeedID",
            DateTime.Now
        );
        IEnumerable<YourModel> topItems = _repository.GetTopItems();
        IEnumerable<SyndicationItem> syndicationItems = topItems.Select(
            item => new SyndicationItem(
                item.Title,
                item.Description,
                new Uri(item.Url),
                item.Id,
                DateTime.Now
            )
        );
        feed.Items = syndicationItems;
        return new RssActionResult() { Feed = feed };
    }
