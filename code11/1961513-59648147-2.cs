    public static class GenericExtensions {
       public static object Map<T>(this T source)
        {
            var fullName = source.GetType().FullName;
            var sourceType = source.GetType();
              
            var baseType = ObjectContext.GetObjectType(source.GetType());
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap(sourceType, baseType));
            
          
            var mapper = config.CreateMapper();
            var entity = mapper.Map(source, sourceType, baseType);
            return entity;
        }
    
    }
    public static List<T> Map<T>(this List<T> original)
    {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap(typeof(T), typeof(T)));
            var mapper = config.CreateMapper();       
            return original.Select(mapper.Map<T, T>).ToList();
    }
