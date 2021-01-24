csharp
		public async Task<Assembly> LoadFromNuget(string id, string version, string? nugetFeedUrl = null, CancellationToken cancellationToken = default)
		{
			var repository = Repository.Factory.GetCoreV3(nugetFeedUrl ?? "https://api.nuget.org/v3/index.json");
			var downloadResource = await repository.GetResourceAsync<DownloadResource>();
			if (!NuGetVersion.TryParse(version, out var nuGetVersion))
			{
				throw new Exception($"invalid version {version} for nuget package {id}");
			}
			using var downloadResourceResult = await downloadResource.GetDownloadResourceResultAsync(
				new PackageIdentity(id, nuGetVersion),
				new PackageDownloadContext(new SourceCacheContext()),
				globalPackagesFolder: Path.GetTempDirectory(),
				logger: _nugetLogger,
				token: cancellationToken);
			if (downloadResourceResult.Status != DownloadResourceResultStatus.Available)
			{
				throw new Exception($"Download of NuGet package failed. DownloadResult Status: {downloadResourceResult.Status}");
			}
			var reader = downloadResourceResult.PackageReader;
			var archive = new ZipArchive(downloadResourceResult.PackageStream);
			var lib = reader.GetLibItems().First()?.Items.First();
			var entry = archive.GetEntry(lib);
			using var decompressed = new MemoryStream();
			entry.Open().CopyTo(decompressed);
			var assemblyLoadContext = new System.Runtime.Loader.AssemblyLoadContext(null, isCollectible: true);
			decompressed.Position = 0;
			return assemblyLoadContext.LoadFromStream(decompressed);
		}
You'll have to implement or use a version of the Nuget ILogger to download the nupkg.
