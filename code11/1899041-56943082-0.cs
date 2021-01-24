public class CustomConfig
{
    public string uri { get; set; }
    public CustomConfig(IConfiguration configuration)
    {
        uri = configuration.GetValue<string>("spring:cloud:config:uri");
    }
}
And then inside my Controller I call the class within the constructor as follows:
private Startup.CustomConfig _customConfig;
public TestController(Startup.CustomConfig customConfig)
{
    _customConfig = customConfig;
}
When I check the `_customConfig` variable it consist my `uri` value. 
I wont mark this as an Answer and will await others suggestion.
