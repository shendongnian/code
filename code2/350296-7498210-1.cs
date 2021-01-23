    DateTime currenteDate = DateTime.UtcNow.Date.AddDays(-2);
    
    var contents = from cnt in context.CmsContents
                       where cnt.IsPublished == true & cnt.IsDeleted == false & cnt.Date >= currenteDate
                       orderby cnt.ContentId descending
                       select new { cnt.ContentId, cnt.Title, cnt.TitleUrl, cnt.Date, cnt.TypeContent };
