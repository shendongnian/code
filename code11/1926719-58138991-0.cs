	public class ApplicationSettingsSetup : IConfigureOptions<ApplicationSettings>
	{
		private readonly IWildcardResolver _wildcardResolver;
		public ApplicationSettingsSetup(IWildcardResolver wildcardResolver)
		{
			_wildcardResolver = wildcardResolver;
		}
		/// <inheritdoc />
		public void Configure(ApplicationSettings options)
		{
			options.PluginFolders = _wildcardResolver.Resolve(options.PluginFolders);
		}
	}
