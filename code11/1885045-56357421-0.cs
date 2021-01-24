	public interface IApplicationConfiguration
	{
		string GetEnvironmentName();
	}
	public class ApplicationConfiguration
	{
		private IHostingEnvironment _hostingConfiguration;
		public ApplicationConfiguration(IHostingEnvironment hostingConfiguration)
		{
			_hostingConfiguration = hostingConfiguration;
		}
		
		public string GetEnvironmentName()
		{
			return _hostingConfiguration.EnvironmentName;
		}
	}
