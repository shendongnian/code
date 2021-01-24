c#
var builder = new ContainerBuilder();
// register common stuff that all plugins use
builder.Register<SomethingCommon>().As<ICommonService>();
var container = builder.Build();
// iterate over the assemblies and create scopes per plugin
var pluginScopes = new List<ILifetimeScope>();
foreach(var assembly in GetThePluginAssemblies())
{
  var scope = container.BeginLifetimeScope(b =>
  {
    b.RegisterAssemblyTypes(assembly)
     .Where(t => t.GetInterfaces().Any(i => i == typeof(IPlugin))
     .AsImplementedInterfaces();
    b.RegisterAssemblyTypes(assembly)
     .Where(t => t.GetInterfaces().Any(i => i == typeof(IMenuItem))
     .AsImplementedInterfaces();
  });
  pluginScopes.Add(scope);
}
At this point, you have a list of separate scopes that you can use to resolve each plugin, like if you needed all the plugins:
c#
var plugins = pluginScopes.SelectMany(s => s.Resolve<IEnumerable<IPlugin>>());
(I _think_ that's how SelectMany works, I always get confused. The point is you'd get a flattened list of all the plugins across all scopes.)
To make your life easy, technically you could use the `Autofac.Multitenant` package and "pretend" that each plugin is a separate tenant. It already has all the scope tracking and configuration per tenant built.
c#
var builder = new ContainerBuilder();
// register common stuff that all plugins use
builder.Register<SomethingCommon>().As<ICommonService>();
var container = builder.Build();
// You probably won't want to resolve things "as a tenant" from the container,
// so you'd only use the Multitenant.ApplicationContainer (for global/common stuff)
// or individual tenant scopes directly. The tenant ID strategy, ostensibly, won't
// be used, so just make a dummy one that always returns false or something.
var multiPluginContainer = new MultitenantContainer(container, SomeTenantIdentificationStrategy);
// iterate over the assemblies and create tenants per plugin
// where the tenant ID is something like the assembly name
foreach(var assembly in GetThePluginAssemblies())
{
  multiPluginContainer.ConfigureTenant(assembly.FullName, b =>
  {
    b.RegisterAssemblyTypes(assembly)
     .Where(t => t.GetInterfaces().Any(i => i == typeof(IPlugin))
     .AsImplementedInterfaces();
    b.RegisterAssemblyTypes(assembly)
     .Where(t => t.GetInterfaces().Any(i => i == typeof(IMenuItem))
     .AsImplementedInterfaces();
  });
}
Then you could get the list of plugins ("tenants") and resolve.
c#
var plugins = multiPluginContainer
  .GetTenants()
  .SelectMany(k =>
    multiPluginContainer.GetTenantScope(k).Resolve<IEnumerable<IPlugin>>());
**Option 2: Use Metadata to Tag Items**
Autofac supports [parameters during registration](https://autofac.readthedocs.io/en/latest/register/parameters.html) and the `ResolvedParameter` is pretty powerful. Some clever work with that can go a long way.
First, you could register all the menu items and tag them with metadata.
c#
var builder = new ContainerBuilder();
// register a bunch of stuff and...
foreach(var assembly in GetThePluginAssemblies())
{
  builder.RegisterAssemblyTypes(assembly)
     .Where(t => t.GetInterfaces().Any(i => i == typeof(IPlugin))
     .AsImplementedInterfaces();
  builder.RegisterAssemblyTypes(assembly)
     .Where(t => t.GetInterfaces().Any(i => i == typeof(IMenuItem))
     .WithMetadata("assembly", assembly.FullName)
     .AsImplementedInterfaces();
}
OK, now you have all the `IMenuItem` entries tagged with the assembly name. Create a module that automatically attaches a resolved parameter to every `IPlugin` such that any `IEnumerable<IMenuItem>` will be fulfilled by your parameter. This is largely based on the [log4net module example from the docs](https://autofac.readthedocs.io/en/latest/examples/log4net.html).
c#
public class MenuItemModule : Autofac.Module
{
  private static void OnComponentPreparing(object sender, PreparingEventArgs e)
  {
    e.Parameters = e.Parameters.Union(
      new[]
      {
        new ResolvedParameter(
            // Only provide values for IEnumerable<IMenuItem> requested
            // by IPlugin implementations
            (pi, ctx) =>
               pi.ParameterType == typeof(IEnumerable<IMenuItem>) &&
               pi.Member.DeclaringType.GetInterfaces().Any(i => i == typeof(IPlugin)),
            // Resolve the appropriately tagged menu items
            // IEnumerable<T> - get all the menu items
            // Meta<T> - you want to look at the metadata
            // Lazy<T> - don't actually construct them until you want them
            // meta.Value = Lazy<T>
            // meta.Value.Value resolves the IMenuItem
            (pi, ctx) => {
              var asmName = pi.Member.DeclaringType.Assembly.FullName;
              return ctx.Resolve<IEnumerable<Meta<Lazy<IMenuItem>>>>()
                 .Where(meta => meta.Metadata["assembly"] == asmName)
                 .Select(meta => meta.Value.Value);
            }
        ),
      });
  }
  protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
  {
    registration.Preparing += OnComponentPreparing;
  }
}
You'd then register that module to ensure all resolutions get that parameter.
c#
builder.RegisterModule<MenuItemModule>();
**There are other options.**
You could imagine other permutations on it. Separate container per plugin (which isn't a bad idea - good isolation of plugins). Separate _AppDomain_ per plugin (even better isolation but work to marshal data). Base `IPlugin` implementation that has the filtering logic in that instead of in a `ResolvedParameter`. Metadata filter attributes on plugin implementations to do the filtering.
Hopefully this helps unblock you.
