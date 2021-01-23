    static class ResultExtensions
    {
        public static Result<TResult> Select<TSource, TResult>(this Result<TSource> source, Func<TSource, TResult> selector)
        {
            if (source.IsError) return new Result<TResult>(source.Error);
            return new Result<TResult>(selector(source.Value));
        }
        public static Result<TResult> SelectMany<TSource, TResult>(this Result<TSource> source, Func<TSource, Result<TResult>> selector)
        {
            if (source.IsError) return new Result<TResult>(source.Error);
            return selector(source.Value);
        }
        public static Result<TResult> SelectMany<TSource, TCollection, TResult>(this Result<TSource> source, Func<TSource, Result<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source.IsError) return new Result<TResult>(source.Error);
            var collection = collectionSelector(source.Value);
            if (collection.IsError) return new Result<TResult>(collection.Error);
            return new Result<TResult>(resultSelector(source.Value, collection.Value));
        }
    }
