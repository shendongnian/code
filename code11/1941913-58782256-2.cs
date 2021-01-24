    public class ComparableReadOnlyCollection<T> : ReadOnlyCollection<T>
    {
        public ComparableReadOnlyCollection(IList<T> list)
            : base(list.ToArray())
        {
        }
        public override bool Equals(object other)
        {
            return
                other is IEnumerable<T> otherEnumerable &&
                otherEnumerable.SequenceEqual(this);
        }
        public override int GetHashCode()
        {
            int hash = 43;
            unchecked {
                foreach (T item in this) {
                    hash = 19 * hash + item.GetHashCode();
                }
            }
            return hash;
        }
    }
