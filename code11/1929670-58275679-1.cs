c#
builder.RegisterType<TenantResolverStrategy>().As<ITenantIdentificationStrategy>();
That's trouble, because every single resolution from the tenant ID strategy is going to go through a single instance of the tenant ID strategy. It's going to be cached. However, resolving the strategy is going to resolve different values and be misleading.
Consider:
c#
var strategy = container.Resolve<ITenantIdentificationStrategy>();
// The multitenant container is CACHING THIS.
var mtc = new MultitenantContainer(container, strategy);
// Now, later on you maybe resolve another instance of the strategy:
var anotherInstance = mtc.Resolve<ITenantIdentificationStrategy>();
// Or from the root:
var thirdInstance = container.Resolve<ITenantIdentificationStrategy>();
// OH NO! strategy != anotherInstance != thirdInstance
// These ARE NOT THE SAME INSTANCE. Tenant determination may CHANGE
// based on which one of these is used.
**Make your tenant ID strategy a singleton.**
Next, since the strategy is cached in the multitenant container, you _can't maintain state_. This is super important because you will run into tons of threading issues.
c#
public class TenantResolverStrategy : ITenantIdentificationStrategy
{
  public TenantResolverStrategy(
    IHttpContextAccessor httpContextAccessor,
    IMemoryCache memoryCache,
    TenantEntity tenantEntity
  )
  {
    this.httpContextAccessor = httpContextAccessor;
    this.memoryCache = memoryCache;
    // PROBLEM! Where is TenantEntity coming from?
    this.tenantEntity = tenantEntity;
  }
  public bool TryIdentifyTenant(out object tenantId)
  {
    tenantId = null;
    var context = httpContextAccessor.HttpContext;
    var hostName = context?.Request?.Host.Value;
    // PROBLEM: Incorrectly storing state in the strategy
    // when this is used across threads. (There's also no
    // explanation of what's in GetTenant, so it's hard to
    // help with that.) 
    tenantEntity = GetTenant(hostName);
    if (tenantEntity != null)
    {
      tenantId = tenantEntity.TenantCode;
    }
    return (tenantId != null || tenantId == (object)"");
  }
}
**You can maintain a cache, but don't maintain state.** For example, maybe you need a `Dictionary<string, object>` to cache hostname to tenant ID mappings, and that's fine (as long as you do locking around that, or use a thread-safe dictionary). But you have a _single object_ that can be overwritten across threads and that's bad news.
Next, I see your tenant ID strategy takes dependencies. _Generally, I'd avoid this and construct it directly._ I know that's not great for some folks, but there is a tendency to "over-DI" things that shouldn't be involved in DI. Manually constructing base objects like a `ContainerBuilder` or your tenant ID strategy ensures you're only looking at things that you can control (and it avoids these exceptions like you've seen).
**You should be able to manually resolve any dependencies that go into the tenant ID strategy.** For example, this should work:
c#
public static MultitenantContainer ConfigureMultitenantContainer(IContainer container)
{
  // These are the dependencies of the strategy. You don't NEED TO DO THIS
  // but if you put these in here, it SHOULD NOT BLOW UP. If it does, you know
  // where to start tracing things down.
  var accessor = container.Resolve<IHttpContextAccessor>();
  var cache = container.Resolve<IMemoryCache>();
  var entity = container.Resolve<TenantEntity>();
  // Here's the strategy - again, make sure it's a SINGLETON!
  var strategy = container.Resolve<ITenantIdentificationStrategy>();
  var mtc = new MultitenantContainer(strategy, container);
  // mtc.ConfigureTenant("a", cb => cb.RegisterType<TenantACustom>().As<ITenantCustom>());
  return mtc;
}
That said, I recognize that things like database connections may need to be injected, in which case, again, be sure things are marked as _singletons_. Your multitenant container tenant ID strategy will live for the lifetime of the application. Plus, nothing that depends on a tenant ID strategy (like the multitenant container) should be tenant-specific or request-based because... you can't determine the tenant without a valid tenant ID strategy. Circular dependency!
So, boiling it all down:
- Register your tenant ID strategy as a singleton.
- Remove all dependencies in the tenant ID strategy that aren't singletons (e.g., `TenantEntity`).
- Use thread-safe caching (e.g., the memory cache) for host-to-tenant-ID mappings, but do not store state (don't keep that `TenantEntity` instance variable; make it a method-level local variable if you need to).
- Make sure everything you need to resolve is registered. If your tenant ID strategy needs `IHttpContextAccessor` (or `IMemoryCache`, or whatever) that needs to be registered. Try resolving those dependencies directly if you run into trouble; that will tell you exactly which component is having problems. (However, if you look through the full stack trace of the exception you're getting, you should see exactly what's going on. You didn't include that exception message in the question, so we can't dive in.)
