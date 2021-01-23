    public static class IMappingExpressionExtensions 
    { 
    public static IMappingExpression<IDictionary, TDestination> ConvertFromDictionary<TDestination>(this IMappingExpression<IDictionary, TDestination> exp, Func<string, string> propertyNameMapper) 
    { 
    foreach (PropertyInfo pi in typeof(Invoice).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) 
    { 
    if (!pi.CanWrite || 
    pi.GetCustomAttributes(typeof(PersistentAttribute), false).Length == 0) 
    { 
    continue; 
    } 
    
    string propertyName = pi.Name; 
    propertyName = propertyNameMapper(propertyName); 
    exp.ForMember(propertyName, cfg => cfg.MapFrom(r => r[propertyName])); 
    } 
    return exp; 
    } 
    } 
    
    Usage: 
    
    Mapper.CreateMap<IDictionary, MyType>() 
    .ConvertFromDictionary(propName => propName) // map property names to dictionary keys 
