    public class InputMapper<TSource> where TSource : new()
    {
        public void Map<TResult>(string input,
                                 Expression<Func<TSource, TResult>> projection,
                                 string text)
        {
            ...
        }
    }
