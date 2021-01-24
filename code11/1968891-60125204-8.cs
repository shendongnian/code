    public class ArticlesBusinessLogic
    {
        public IEnumerable<Article> Search(ArticlesSearchModel model)
        {
            using (var db = new ArticlesDBEntities())
            {
                var result = db.Articles.Include(x => x.Authors).AsQueryable();
                if (model == null)
                    return result.ToList();
                if (!string.IsNullOrEmpty(model.SearchTerm))
                {
                    result = result.Where(article => (
                        article.Title.Contains(model.SearchTerm) ||
                        article.Abstract.Contains(model.SearchTerm) ||
                        article.Authors.Any(author =>
                        (author.FirstName + " " + author.LastName).Contains(model.SearchTerm))
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
    }
