    public class SequenceEqualityComparer<TElement> : EqualityComparer<IEnumerable<TElement>>
    {
        private readonly IEqualityComparer<TElement> _elementEqualityComparer;
        public SequenceEqualityComparer()
            : this(null)
        { }
        public SequenceEqualityComparer(IEqualityComparer<TElement> elementEqualityComparer)
        {
            _elementEqualityComparer = elementEqualityComparer ?? EqualityComparer<TElement>.Default;
        }
        public new static SequenceEqualityComparer<TElement> Default { get; } = new SequenceEqualityComparer<TElement>();
        public override bool Equals(IEnumerable<TElement> x, IEnumerable<TElement> y)
        {
            if (object.ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            if (x is ICollection<TElement> xCollection &&
                y is ICollection<TElement> yCollection &&
                xCollection.Count != yCollection.Count)
                return false;
            return x.SequenceEqual(y, _elementEqualityComparer);
        }
        public override int GetHashCode(IEnumerable<TElement> sequence)
        {
            if (sequence == null)
                return 0;
            unchecked
            {
                const uint fnvPrime = 16777619;
                uint hash = 2166136261;
                foreach (uint item in sequence.Select(_elementEqualityComparer.GetHashCode))
                    hash = (hash ^ item) * fnvPrime;
                return (int)hash;
            }
        }
    }
