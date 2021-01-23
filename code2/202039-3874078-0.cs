    public class CurrentNext<T>
    {
        public T Current { get; private set; }
        public T Next { get; private set; }
    
        public CurrentNext(T current, T next)
        {
            Current = current;
            Next = next;
        }
    }
    
    ...
    
    public static IEnumerable<CurrentNext<T>> ToCurrentNextEnumerable<T>(this IEnumerable<T> source)
    {
        if (source == null)
            throw new ArgumentException("source");
    
        using (var source = enumerable.GetEnumerator())
        {
            if (!enumerator.MoveNext())
                yield break;
    
            T current = enumerator.Current;
    
            while (enumerator.MoveNext())
            {
                yield return new CurrentNext<T>(current, enumerator.Current);
                current = enumerator.Current;
            }
        }
    }
