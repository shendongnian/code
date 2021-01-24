    using (var context = new NewsDbContext())
    {
        var categoriesWithNews = context.News.GroupBy(x => x.Category)
            .Select(x => new
            {
                Category = x.Key,
                News = x.OrderBy(n => n.CreatedDate).Take(6).ToList()
            }).ToList();
    }
