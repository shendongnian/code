    public class NewsRepository : INewsRepository
    {
       private readonly INewsRepository newsRepository;
    
       public NewsRepository(INewsRepository newsRepository)
       {
          this.newsRepository = newsRepository;
       }
       public IEnumerable<News> FindAll()
       {
          return null;
       }
    }
