    public interface IRepository<TEntity> where TEntity : IdEntity
    {
       /* ...snip... */
        IList<TEntity> Find(ISpecification<TEntity> query);
    }
    public interface ISpecification<T> { bool Matches(T item);  }
