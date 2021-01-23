    static class MapperHelper
    {    
        static void Register<TSource, TDestination>()
        {
            var mapped = Mapper.FindTypeMapFor(typeof(TSource), typeof(TDestination));
            if (mapped == null)
            {
                var expression = Mapper.CreateMap<TSource, TDestination>();
            }
        }
        static TDestination QuickMap<TSource, TDestination>(this TSource source)
        {
             return Mapper.Map<TSource, TDestination>(source);
        }
    }
