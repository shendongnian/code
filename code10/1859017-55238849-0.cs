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
            var xCollection = x as ICollection<TElement>;
            if (xCollection != null)
            {
                var yCollection = y as ICollection<TElement>;
                if (yCollection != null)                    
                {
                    if (xCollection.Count != yCollection.Count)
                        return false;
                }
            }
            return x.SequenceEqual(y, _elementEqualityComparer);
        }
        public override int GetHashCode(IEnumerable<TElement> sequence)
        {
            if (sequence == null)
                return 0;
            return HashCodeCombiner.Combine(sequence, _elementEqualityComparer);
        }        
    }
