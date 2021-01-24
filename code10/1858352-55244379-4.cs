 c#
public class XHelper
{
    private readonly IConfiguracion config;
    
    public XHelper(IConfiguracion config)
    {
        this.config = config ?? throw new ArgumentNullException(nameof(config));
    }
    public TResponse Execute(string metodo, TRequest request)
    {
        string y = this.config.apiUrl;  //i need it
        return xxx; //xxxxx
    }
}
### 2. Supply the `IConfiguracion` to the `Execute` method through Method Injection.
Example:
 c#
public static class XHelper
{
    public static TResponse Execute(
        string metodo, TRequest request, IConfiguracion config)
    {
        if (config is null) throw new ArgumentNullException(nameof(config));
    
        string y = config.apiUrl;
        return xxx;
    }
}
All other options are off the table because they would either cause code smells or anti-patterns. For instance, you might be inclined to use the Service Locator pattern, but that's a bad idea because that's [an anti-pattern][3]. Property Injection, on the other hand, causes [Temporal Coupling][4], which is a code smell.
  [1]: https://mng.bz/oN9j
  [2]: https://mng.bz/jONp
  [3]: https://mng.bz/WaQw
  [4]: https://blog.ploeh.dk/2011/05/24/DesignSmellTemporalCoupling/
