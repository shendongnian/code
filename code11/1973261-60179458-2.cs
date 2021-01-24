    var newsListItems = db.News
        .Where(n => n.NewsDate >= newsDate && n.NewsDate < cutOff)
        .SelectMany(n => n.NewsImages
            .Where(ni => ni.FileOrder == 10)
            .Select(ni => new NewsList
            {
                NewsGuid = n.NewsGuid,
                Heading = n.Heading,
                FileName = ni.FileName
            })).OrderByDescending(n => n.NewsDate)
           .Take(10).ToList();
