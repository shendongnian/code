    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
    public class MyMapper :IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            AutoMapper.Mapper.CreateMap<TSource, TDestination>();
            return AutoMapper.Mapper.Map<TSource, TDestination>(source);
        }
    }
