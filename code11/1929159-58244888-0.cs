public class LogAttribute : Attribute, IFilterFactory
{
    public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetService<LogFilter>();
    }
}
public class LogFilter : IActionFilter // or IAsyncActionFilter
{
    public LogFilter( DbContext db )
    {
        
    }
}
