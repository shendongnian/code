csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(@"our-secret-path-goes-here"));
}
And since then, everything works like a charm.
