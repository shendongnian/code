csharp
public class MyService : IMyService
{
    public MyService(IOtherService otherService, IOptions<ConfigurationSettings> configurationSettings)
    {
         // read config value from here.
    }
}
`
