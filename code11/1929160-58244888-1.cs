// This class is the attribute. Note that it is not an action filter itself.
// This class cannot have DI constructor injection, but it can access the IServiceProvider.
public class LogAttribute : Attribute, IFilterFactory
{
    public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetService<LogFilter>();
    }
}
// This class is the actual filter. It is not an attribute.
// This class *can* have DI constructor injection.
public class LogFilter : IActionFilter // or IAsyncActionFilter
{
    public LogFilter( DbContext db )
    {
        
    }
}
A full example can be found here:  ( https://www.devtrends.co.uk/blog/dependency-injection-in-action-filters-in-asp.net-core )
