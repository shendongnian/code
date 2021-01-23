    public static class Covariance
    {
        public static IIndexedEnumerable<T> AsCovariant<T>(this IList<T> tail)
        {
            return new CovariantList<T>(tail);
        }
        private class CovariantList<T> : IIndexedEnumerable<T>
        {
            private readonly IList<T> tail;
            public CovariantList(IList<T> tail)
            {
                this.tail = tail;
            }
            public T this[int index] { get { return tail[index]; } }
            public IEnumerator<T> GetEnumerator() { return tail.GetEnumerator();}
            IEnumerator IEnumerable.GetEnumerator() { return tail.GetEnumerator(); }
        }
    }
    public interface IIndexedEnumerable<out T> : IEnumerable<T>
    {
        T this[int index] { get; }
    }
