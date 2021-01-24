        public abstract class BaseEntity<TKey> : IIdentifiable<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
    public interface IIdentifiable<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
