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
        public static Result<TResult> SelectMany<TSource, TIntermediate, TResult>(this Result<TSource> source, Func<TSource, Result<TIntermediate>> intermediateSelector, Func<TSource, TIntermediate, TResult> resultSelector)
        {
            if (source.IsError) return new Result<TResult>(source.Error);
            var intermediate = intermediateSelector(source.Value);
            if (intermediate.IsError) return new Result<TResult>(intermediate.Error);
            return new Result<TResult>(resultSelector(source.Value, intermediate.Value));
        }
    }
