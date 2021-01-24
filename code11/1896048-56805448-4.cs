    public abstract class BaseEntity<TKey2> : IIdentifiable<TKey2> where TKey2 : IEquatable<TKey2>
    {
        public TKey2 Id { get; set; }
    }
    public interface IIdentifiable<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
 
