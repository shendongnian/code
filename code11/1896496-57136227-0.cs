c#
public override void Initialize()
{
    var thisAssembly = ...
    IocManager.RegisterAssemblyByConvention(thisAssembly);
    IocManager.IocContainer.Register(
        Classes.FromAssembly(thisAssembly)
            .BasedOn(typeof(IQueryService<>))
            .WithService.Base()
            .Configure(configurer => configurer.Named(Guid.NewGuid().ToString())) // Add this
    );
    // ...
}
<sup>1</sup> If your concrete class implements ASP.NET Boilerplate's `ITransientDependency`, then the default name is used to register the class for `.WithService.Self()` inside `RegisterAssemblyByConvention`.
# 2. `IRepository<SomeType>`
> Castle.MicroKernel.Handlers.HandlerException: Can't create component 'AbpCompanyName.AbpProjectName.SomeEntityService.SomeTypeService' as it has dependencies to be satisfied.
>
> 'AbpCompanyName.AbpProjectName.SomeEntityService.SomeTypeService' is waiting for the following dependencies:  
> - Service 'Abp.Domain.Repositories.IRepository`1[[AbpCompanyName.AbpProjectName.SomeEntities.SomeType, AbpCompanyName.AbpProjectName.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]' which was not registered.
To use ASP.NET Boilerplate repositories, define a **public** DbSet.
c#
public class AbpProjectNameDbContext : ...
{
    /* Define a DbSet for each entity of the application */
    // DbSet<SomeType> SomeEntities { get; set; }     // Remove this
    public DbSet<SomeType> SomeEntities { get; set; } // Add this
    // ...
}
