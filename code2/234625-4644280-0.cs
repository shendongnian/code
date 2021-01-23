    var begin = new DateTime(2011, 1, 1);
    var end = begin.AddHours(24);
    
    Apps = (from app in context.Instances
                 where 
                   (app.ReleaseDate >= begin) and
                   (app.ReleaseDate < end)
                 select new ScalpApp
                 {
                 Image = app.Image,
                 PublisherName = app.PublisherName,
                 }).ToList();
