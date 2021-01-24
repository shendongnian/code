    public class BaseEntity
    {
        public bool Active { get; protected set; }
    
        public DateTimeOffset CreatedAt { get; protected set; }
    
        public string CreatedBy { get; protected set; }
    
        public DateTimeOffset? ModifiedAt { get; protected set; }
    
        public string ModifiedBy { get; protected set; }
    }
    public class BaseEntity<TKey> : BaseEntity
    {
        public TKey Id { get; protected set; }
    }
