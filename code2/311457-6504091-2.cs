    public class ListEqualityComparer<T> : IEqualityComparer<List<T>>
    {
        private static readonly EqualityComparer<T> ElementComparer =
            EqualityComparer<T>.Default;
        public int GetHashCode(List<T> input)
        {
            if (input == null)
            {
                return 0;
            }
            // Could use Aggregate for this...
            int hash = 17;
            foreach (T item in input)
            {
                hash = hash *31 + ElementComparer.GetHashCode(item);
            }
            return hash;
        }
        public bool Equals(List<T> first, List<T> second)
        {
            if (first == second)
            {
                return true;
            }
            if (first == null || second == null)
            {
                return false;
            }
            return first.SequenceEqual(second, ElementComparer);
        }
    }
