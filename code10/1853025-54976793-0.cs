 c#
container.Register(typeof(IEntityRepository<,>), typeof(EntityRepository<,>));
container.Register<IProductsDbContext, ProductsDbContext>();
There is no `AsImplementedInterfaces` equivalent in Simple Injector, although there are several ways to achieve rhe same. In the case that `ProductsDbContext` has multiple interfaces that need to be registered, the most obvious way is to register each interface explicitly:
 c#
container.Register<IProductsDbContext, ProductsDbContext>();
container.Register<IUsersDbContext, ProductsDbContext>();
container.Register<ICustomersDbContext, ProductsDbContext>();
