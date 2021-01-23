    public static class PowerBuilderConfigParser
	{
		public static IList<PowerBuilderConfig> ReadConfigFile(String path)
		{
			IList<PowerBuilderConfig> configs = new List<PowerBuilderConfig>();
			using (FileStream stream = new FileStream(path, FileMode.Open))
			{
				
				XmlReader reader = XmlReader.Create(stream);
				reader.ReadToDescendant("PowerBuilderRunTime");
				do
				{
					PowerBuilderConfig config = new PowerBuilderConfig();
					ReadVersionNumber(config, reader);
					ReadFiles(config, reader);
					configs.Add(config);
				} while (reader.ReadToNextSibling("PowerBuilderRunTime"));
			}
			return configs;
		}
		private static void ReadVersionNumber(PowerBuilderConfig config, XmlReader reader)
		{
			
			reader.ReadToDescendant("Version");
			string version = reader.ReadString();
			Int32 versionNumber;
			if (Int32.TryParse(version, out versionNumber))
			{
				config.Version = versionNumber;
			}
		}
		private static void ReadFiles(PowerBuilderConfig config, XmlReader reader)
		{
			reader.ReadToNextSibling("Files");
			reader.ReadToDescendant("File");
			do
			{
				string file = reader.ReadString();
				if (!string.IsNullOrEmpty(file))
				{
					config.AddConfigFile(file);
				}
			} while (reader.ReadToNextSibling("File"));
		}
	}
	public class PowerBuilderConfig
	{
		private Int32 _version;
		private readonly IList<String> _files;
		public PowerBuilderConfig()
		{
			_files = new List<string>();
		}
		public Int32 Version
		{
			get { return _version; }
			set { _version = value; }
		}
		public ReadOnlyCollection<String> Files
		{
			get { return new ReadOnlyCollection<String>(_files); }
		}
		public void AddConfigFile(String fileName)
		{
			_files.Add(fileName);
		}
	}
