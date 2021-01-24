csharp
static async Task Main(string[] args)
{
    var packageSource = new PackageSource("https://api.nuget.org/v3/index.json");
    var sourceRepository = new SourceRepository(packageSource, FactoryExtensionsV3.GetCoreV3(null));
    var metadata = await sourceRepository.GetResourceAsync<MetadataResource>();
    var cacheContext = new SourceCacheContext();
    var versions = await metadata.GetVersions("newtonsoft.json", cacheContext, NullLogger.Instance, CancellationToken.None);
    foreach (var version in versions)
    {
        Console.WriteLine("Found version " + version.ToNormalizedString());
    }
}
