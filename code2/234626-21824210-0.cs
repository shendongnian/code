    DateTime begin = new DateTime(2011, 1, 1);
    
    Apps = (from app in context.Instances
            where EntityFunctions.TruncateTime(app.ReleaseDate) == begin
            select new ScalpApp {
                Image = app.Image,
                PublisherName = app.PublisherName,
            }).ToList();
