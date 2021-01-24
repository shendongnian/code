    public struct ContextCacheKey : IEquatable<ContextCacheKey>
    {
        public static bool operator ==(ContextCacheKey left, ContextCacheKey right) => left.Equals(right);
        public static bool operator !=(ContextCacheKey left, ContextCacheKey right) => !left.Equals(right);
        public readonly object _source;
        public readonly Type _destinationType;
        public ContextCacheKey(object source, Type destinationType)
        {
            _source = source;
            _destinationType = destinationType;
        }
        public override int GetHashCode() => HashCodeCombiner.Combine(_source, _destinationType);
        public bool Equals(ContextCacheKey other) =>
            _source == other._source && _destinationType == other._destinationType;
        public override bool Equals(object other) => 
            other is ContextCacheKey && Equals((ContextCacheKey)other);
    }
