    public class Wrapper<TSource>
    {
       private readonly Task<IEnumerable<TSource>> _sourceCollection;
       public Wrapper(Task<IEnumerable<TSource>> source) 
          =>_sourceCollection = source;
          
       public async Task<IEnumerable<TDest>> To<TDest>()
          => (IEnumerable<TDest>)Mapper.Map(await _sourceCollection, _sourceCollection.GetType(), typeof(IEnumerable<TDest>));
    }
    
    public static class Extensions
    {
       public static Wrapper<TSource> Map<TSource>(this Task<IEnumerable<TSource>> source)
          => new Wrapper<TSource>(source);
    }
