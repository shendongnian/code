    public abstract class IdBase
    {
        public abstract Guid Value { get; protected set; }
    
        public static bool operator == (IdBase left, IdBase right)
        {
            return left.Value == right.Value;
        }
    }
    
    public sealed class Id<TDiscriminator> : IdBase
    {
       // your implementation here, just remember the override keyword for the Value property
    }
