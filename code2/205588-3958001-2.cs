    public class ArticleRepository
    {
       private IObjectContext _ctx;
    
       public ArticleRepository(IObjectContext ctx)
       {
          _ctx = ctx;
       }
       public IQueryable<Article> Find()
       {
          return _ctx.Articles;
       }
    }
