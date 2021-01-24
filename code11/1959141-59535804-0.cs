    public abstract class ItemBase<TId>
    {
        protected ItemBase(TId id)
        {
            ItemId = id;
        }
        public TId ItemId { get; }
        
    }
    public class Toy : ItemBase<int>
    {
        public Toy(int id) : base(id)
        {
        }
    }
    public class NotAToy : ItemBase<Guid>
    {
        public NotAToy(Guid id) : base(id)
        {
        }
    }
