c#
IServiceProvider provider = ...;
using (var scope = provider.CreateScope())
{
    var context = scope.ServiceProvider.GetService<MyNeededDbContext>();
    ...
}
