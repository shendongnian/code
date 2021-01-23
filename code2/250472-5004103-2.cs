    public class ArticleRepository
    {
        private MyEntityContext _entity = new MyEntityContext();
        public IEnumerable<Article> GetArticleArchivesByCategoryAndID(string category, string id)
        {
            var articles = from c in _entity.Articles
                where (c.Category == category && c.ArtCatID == id)
                orderby c.ID
                select c;
        return articles;
        }
  
    }
