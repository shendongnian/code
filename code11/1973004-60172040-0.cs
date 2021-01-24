    string date = Request.QueryString["date"] ?? "";
    int sqlTop = 20;
    DateTime? newsDate = null;
    if (DateTime.TryParse(date, out newsDate))
    {
        sqlTop = 50;
    }
    using (NewsEntities db = new NewsEntities())
    {
        // grab the "News" entries - include the "NewsImage" navigation property
        var query = db.News.Include(n => n.NewsImage);
        // if you have a valid date - use that to refine the query
        if (newsDate.HasValue)
        {
            query = query.Where(n => n.NewsDate == newsDate.Value);
        }
        // order by NewsDate, and select only "sqlTop" entries 
        query = query.OrderByDescending(n => n.NewsDate
                     .Take(sqlTop);
        // now you can iterate over the "News" objects returned from the query
        foreach(News n in query)
        {
           // do whatever you want with your news - output what you need
        }
    }
