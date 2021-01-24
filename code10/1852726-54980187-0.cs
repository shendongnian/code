    var result = model.Content.Children<NewsItem>().Select(newsItem => new
    {
        OrderDate = newsItem.PublishedDate ?? newsItem.CreatedDate,
        Item = newsItem,
    })
    .OrderBy(newsItem => newsItem.OrderDate)
    // if desired, throw away the OrderDate:
    .Select(newsItem => newsItem.Item)
