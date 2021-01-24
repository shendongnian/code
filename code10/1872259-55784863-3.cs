    public class EntityHolder<TTarget, TEntity>
    {
        public TTarget Target { get; }
     
        public EntityHolder(TTarget target)
        {
            Target = target;
        }
    }
    public class PersonsRepository
        : IRepository<Person>, IReadableRepository<Person>,
          IListableRepository<Person>
    {
        public IQueryable<Person> Entities { get; } = ...
        // This is the added property getter
        public EntityHolder<PersonsRepository, Person> FixTypes =>
            new EntityHolder<PersonsRepository, Person>(this);
    }
    public static class MixedRepositoryExtensions 
    {
        // Note that method is attached to EntityHolder, not a repository
        public static Task<TEntity> FindBySelectorAsync<TRepository, TEntity, TSelector>(
            this EntityHolder<TRepository, TEntity> repository, TSelector selector)
            where TRepository : IReadableRepository<TEntity>, IListableRepository<TEntity>
            where TEntity : class, ISearchableEntity<TSelector>
            => repository.Target.Entities.SingleOrDefaultAsync(x => x.Matches(selector));
            // Note that Target must be added before accessing Entities
    }
