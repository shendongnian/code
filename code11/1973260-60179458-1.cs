    var newsListItems = db.News
        .Where(n => n.NewsDate >= newsDate && n.NewsDate < cutOff)
        .SelectMany(n => n.NewsImages
            .Where(ni => ni.FileOrder == 10)
            .Select(ni => new NewsList
            {
                NewsGuid = n.NewsGuid,
                Heading = n.Heading,
                FileName = ni.FileName
            })).Union( db.News
               .Where(n => n.NewsDate >= newsDate && n.NewsDate < cutOff 
                   && !n.NewsImages.Any(ni => ni.FileOrder == 10)
               .Select(n => new NewsList
               {
                   NewsGuild = n.NewsGuid,
                   Heading = n.Heading
               })).OrderByDescending(n => n.NewsDate)
               .Take(10).ToList();
