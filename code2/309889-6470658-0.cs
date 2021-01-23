    public static class PagingExtensions
    {
    //used by LINQ to SQL
    public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, int page, int pageSize)
     {
    return source.Skip((page - 1)*pageSize).Take(pageSize);
     }
    
    //used by LINQ
    public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
     {
    return source.Skip((page - 1)*pageSize).Take(pageSize);
     }
    
    }
    
    class Program
    {
    static void Main(string[] args)
     {
    List<string> names = new List<string>();
     names.AddRange(new string[]{"John","Frank","Jeff","George","Bob","Grant", "McLovin"});
    foreach (string name in names.Page(2, 2))
     {
    Console.WriteLine(name);
     }
    
     }
    }
