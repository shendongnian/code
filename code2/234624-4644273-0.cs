    DateTime begin = new DateTime(2011, 1, 1);
    DateTime end = new DateTime(2011, 1, 2);
    Apps = (from app in context.Instances
                 where 
                   (app.ReleaseDate >= begin) and
                   (app.ReleaseDate < end)
                 select new ScalpApp
                 {
                 Image = app.Image,
                 PublisherName = app.PublisherName,
                 }).ToList();
