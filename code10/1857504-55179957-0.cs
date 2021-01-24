 c#
// As this type depends on your DI library, you should place this type inside your
// Composition Root.
public class LazyDbRepositoryProxy<T> : IDbRepository<T>
{
    private readonly Lazy<IDbRepository<T>> wrapped;
    public LazyDbRepositoryProxy(Container container)
    {
        this.wrapped = new Lazy<IMyService>(container.GetInstance<DbRepository<T>>));
    }
}
And register your types as follows:
 c#
container.Register(typeof(DbRepository<>));
container.Register(typeof(IDbRepository<>), typeof(LazyDbRepositoryProxy<>));
