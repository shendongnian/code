    public interface IMapper<T> : IMapper where T : class
    {
    }
    public class NewsMapper : IMapper<News>
    {
       static NewsMapper()
       {
          Mapper.CreateMap<News, NewsEditViewData>();
          Mapper.CreateMap<NewsEditViewData, News>();
       }
    
       public object Map(object source, Type sourceType, Type destinationType)
       {
          return Mapper.Map(source, sourceType, destinationType);
       }
    }
    public NewsController(INewsService newsService, IMapper<News> newsMapper)
    {
    }
