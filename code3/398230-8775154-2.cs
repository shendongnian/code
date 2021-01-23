    public static class LinqExtensions
    {
        public static Countable<T> AsCount<T>(this IEnumerable<T> source)
        {
            return new Countable<T>(source);
        }
    }
    public class Countable<T>
    {
        private readonly IEnumerable<T> m_source;
        public Countable(IEnumerable<T> source)
        {
            m_source = source;
        }
        public Countable<T> Where(Func<T, bool> predicate)
        {
            return new Countable<T>(m_source.Where(predicate));
        }
        public Countable<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            return new Countable<TResult>(m_source.Select(selector));
        }
        // other LINQ methods
        public static implicit operator int(Countable<T> countable)
        {
            return countable.m_source.Count();
        }
    }
