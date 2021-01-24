public interface INeedsDependency
{
    IDependency InjectedDependency { get; }
}
public class NeedsDependency : INeedsDependency
{
    private readonly IDependency _dependency;
    public NeedsDependency(IDependency dependency)
    {
        _dependency = dependency;
    }
    public IDependency InjectedDependency => _dependency;
}
public interface IAlsoNeedsDependency
{
    IDependency InjectedDependency { get; }
}
public class AlsoNeedsDependency : IAlsoNeedsDependency
{
    private readonly IDependency _dependency;
    public AlsoNeedsDependency(IDependency dependency)
    {
        _dependency = dependency;
    }
    public IDependency InjectedDependency => _dependency;
}
public interface IDependency { }
public class DependencyVersionOne : IDependency { }
public class DependencyVersionTwo : IDependency { }
How do we configure this so that `NeedsDependency` gets `DependencyVersionOne` and `AlsoNeedsDependency` gets `DependencyVersionTwo`?
Here it is in the form of a unit test. Writing it this way make it easy to verify that we're getting the result we expect.
    [TestClass]
    public class TestNamedDependencies
    {
        [TestMethod]
        public void DifferentClassesGetDifferentDependencies()
        {
            var services = new ServiceCollection();
            var serviceProvider = GetServiceProvider(services);
            var needsDependency = serviceProvider.GetService<INeedsDependency>();
            Assert.IsInstanceOfType(needsDependency.InjectedDependency, typeof(DependencyVersionOne));
            var alsoNeedsDependency = serviceProvider.GetService<IAlsoNeedsDependency>();
            Assert.IsInstanceOfType(alsoNeedsDependency.InjectedDependency, typeof(DependencyVersionTwo));
        }
        private IServiceProvider GetServiceProvider(IServiceCollection services)
        {
            /*
             * With Autofac, ContainerBuilder and Container are similar to
             * IServiceCollection and IServiceProvider.
             * We register services with the ContainerBuilder and then
             * use it to create a Container.
             */
            var builder = new ContainerBuilder();
            /*
             * This is important. If we already had services registered with the
             * IServiceCollection, they will get added to the new container.
             */
            builder.Populate(services);
            /*
             * Register two implementations of IDependency.
             * Give them names. 
             */
            builder.RegisterType<DependencyVersionOne>().As<IDependency>()
                .Named<IDependency>("VersionOne")
                .SingleInstance();
            builder.RegisterType<DependencyVersionTwo>().As<IDependency>()
                .Named<IDependency>("VersionTwo")
                .SingleInstance();
            /*
             * Register the classes that depend on IDependency.
             * Specify the name to use for each one.
             * In the future, if we want to change which implementation
             * is used, we just change the name.
             */
            builder.Register(ctx => new NeedsDependency(ctx.ResolveNamed<IDependency>("VersionOne")))
                .As<INeedsDependency>();
            builder.Register(ctx => new AlsoNeedsDependency(ctx.ResolveNamed<IDependency>("VersionTwo")))
                .As<IAlsoNeedsDependency>();
            // Build the container
            var container = builder.Build();
            /*
             * This last step uses the Container to create an AutofacServiceProvider,
             * which is an implementation of IServiceProvider. This is the IServiceProvider
             * our app will use to resolve dependencies.
             */
            return new AutofacServiceProvider(container);
        }
    }
The unit test resolves both types and verifies that we've injected what we expect. 
Now, how do we take this and put it in a "real" application?
In your `Startup` class, change
    public void ConfigureServices(IServiceCollection services)
to
    public IServiceProvider ConfigureServices(IServiceCollection services)
Now `ConfigureServices` will return an `IServiceProvider`. 
Then, you can add the Autofac `ContainerBuilder` steps to `ConfigureServices` and have the method return `new AutofacServiceProvider(container);`
If you're already registering services with the `IServiceCollection`, that's fine. Leave that as it is. Whatever services you need to register with the Autofac `ContainerBuilder`, register those.
Just make sure you include this step:
    builder.Populate(services);
So that whatever was registered with the `IServiceCollection` also gets added to the `ContainerBuilder`.
---
This might seem a tiny bit convoluted as opposed to just making something work with the provided IoC container. The advantage is that once you get over that hump, you can leverage the helpful things that other containers can do. You might even decide to use Autofac to register all of your dependencies. You can search for different ways to register and use named or keyed dependencies with Autofac, and all of those options are available to you. (Their [documentation](https://autofac.org/) is great.) You can also use [Windsor](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/) or others.
Dependency injection was around long before `Microsoft.Extensions.DependencyInjection`, `IServiceCollection`, and `IServiceProvider`. It helps to learn how to do the same or similar things with different tools so that we're working with the underlying concepts, not just a specific implementation.
Here is [some more documentation](https://autofaccn.readthedocs.io/en/latest/integration/aspnetcore.html) from Autofac specific to using it with ASP.NET Core. 
