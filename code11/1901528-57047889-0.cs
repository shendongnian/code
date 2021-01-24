class IntegrationConfig
{
    public int Timeout { get; set; }
    public string Name { get; set; }
}
Then you need to add this config to the DI-system: 
services.AddSingleton(new IntegrationConfig
{
    Timeout = 1234,
    Name = "Integration name"
});
In the class `IntegrationService` you need to add a constructor which takes an object of the config:
public IntegrationService(IntegrationConfig config)
{
    // setup with config or simply store config
}
That's basically all you need. It's not the prettiest solution in my opinion and in `.net core 3` 
you can simply use a factory func to add the HostedService but I think something like this is the best choice 
if you're on `.net core 2.2` or below.
