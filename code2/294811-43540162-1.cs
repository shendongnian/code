    // Wrap ProductRepository with CachingProductRepository,
    // injecting ProductRepository into CachingProductRepository for
    // IProductRepository
    container.Decorate<IProductRepository, ProductRepository, CachingProductRepository>();
    // Wrap CachingProductRepository with LoggingProductRepository,
    // injecting CachingProductRepository into LoggingProductRepository for
    // IProductRepository
    container.Decorate<IProductRepository, CachingProductRepository, LoggingProductRepository>();
