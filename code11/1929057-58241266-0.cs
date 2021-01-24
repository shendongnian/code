    public interface IConfiguration 
    {
		string WorkingDirectory { get; }
	}
	
	public class ConfigurationManagerProvider: IConfiguration 
	{
		public WorkingDirectory => ConfigurationManager.AppSettings["WorkingDirectory"];
	}
	
