    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        protected JobsLedgerAPIContext Context { get; set; }
        
        // rest of the code ....
    }
