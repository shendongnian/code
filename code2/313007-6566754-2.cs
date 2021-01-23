    public class EntityRepository : Repository<Entity>
    {
        public EntityRepository(IActiveSessionManager activeSessionManger)
            : base(activeSessionManger)
        {
        }
        public Entity GetByName(string name)
        {
            var criteria = NHibernate.Criterion.DetachedCriteria.For<Entity>()
                .Add(Restrictions.Eq("name", name));
            return FindOne(criteria);
        }
        public IList<Entity> returnsomething()
        {
        }
        ....
    }
