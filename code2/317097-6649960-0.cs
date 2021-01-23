    public class Repository : IRepository
    {
        private Datacontext context;
        public Repository()
        {
            context = new Datacontext();
        }
        public IQueryabale<Entity> SelectAllEntities()
        {
             return context.Entity.Where(e=>! e.IsObsolote);
        }
        public IQueryable<Entity> SelectAllEntityRelatedToAnotherEntity(Entity otherEntity)
        {
             return this.SelectAllEntities().Where(e=>e.RelatedEntityId == otherEntity.Id);
        }
    }
