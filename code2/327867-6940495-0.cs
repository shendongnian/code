	public interface IMyPlugin
	{
		void DoSomethingPlugInIsh();
	}
	class Program
	{
		static void Main(string[] args)
		{
			IMyPlugin plugin1 = CreateFromConfig<IMyPlugin>("PluginType");
			plugin1.DoSomethingPlugInIsh();
			// etc...
		}
		static T CreateFromConfig<T>(string typeSettingName)
			where T : class
		{
			string typeName = ConfigurationManager.AppSettings[typeSettingName];
			if (string.IsNullOrEmpty(typeName))
				return null;
			var type = Type.GetType(typeName);
			return (T)Activator.CreateInstance(type);
		}
		
	}
