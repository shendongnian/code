    public abstract class EntityConductor<T> : IEntityViewModel<T>
        where T : class, ICLEntity
    {
        public T Entity { get; set; }
    
        ICLEntity IEntityViewModel.Entity
        {
            get { return Entity; }
            set { Entity = (T)value; }
        }
    }
