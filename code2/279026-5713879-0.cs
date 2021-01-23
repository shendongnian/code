    public static class EnumerableHelper
    {
        public static IEnumerable<TResult> Cast<TResult>(IEnumerable source)
        {
            IEnumerable<TResult> enumerable = source as IEnumerable<TResult>;
            if (enumerable != null) return enumerable;
            if (source == null) throw new ArgumentNullException("source");        
            foreach(object element in source)
            {
                yield return (TResult) element;
            }
        }
    }
