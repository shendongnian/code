    public class ArticleRepository : IDisposable
    {
       ArticleNetEntities db;
    
       public ArticleRepository()
       {
          db = new ArticleNetEntities();
       }
    
       public List<Article> GetArticles()
       {
          List<Article> articles = null;
          db.Articles.Where(something).Take(some).ToList();
       }
    
       public void Dispose()
       {
          db.Dispose();
       }
    
    }
