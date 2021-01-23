    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.DependencyResolution;
    using System.Data.Entity.Infrastructure.Pluralization;
    var service = DbConfiguration.DependencyResolver.GetService<IPluralizationService>();
    var entitySetName = service.Pluralize(typeof(TEntity).Name));
