    public class ArticleRepository
    {
       public List<Article> GetArticles()
       {
          List<Article> articles = null;
      
          using (var db = new ArticleNetEntities())
          {
             articles = db.Articles.Where(something).Take(some).ToList();
          }
       }
    }
