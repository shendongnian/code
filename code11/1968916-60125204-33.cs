    public IEnumerable<Article> Search(ArticlesSearchModel model)
    {
        using (var db = new ArticlesDbContext())
        {
            var result = db.Articles.Include(x=>x.ArticleAuthor)
                                    .ThenInclude(x=>x.Author)
                                    .AsQueryable();
            if (model == null)
                return result;
            if (!string.IsNullOrEmpty(model.SearchTerm))
            {
                result = result.Where(article => (
                    article.Title.Contains(model.SearchTerm) ||
                    article.Abstract.Contains(model.SearchTerm) ||
                    article.ArticleAuthor.Any(au =>
                        (au.Author.FirstName + " " + au.Author.LastName)
                            .Contains(model.SearchTerm))
                ));
            }
            if (model.PublishDateFrom.HasValue)
            {
                result = result.Where(x => x.PublishDate >= model.PublishDateFrom);
            }
            if (model.PublishDateFrom.HasValue)
            {
                result = result.Where(x => x.PublishDate <= model.PublishDateTo);
            }
            return result.ToList();
        }
    }
