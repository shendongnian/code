    public class PowerBuilderConfigParser
	{
		private Int32 _version;
		private IList<String> _files;
		public Int32 Version
		{
			get { return _version; }
			private set { _version = value; }
		}
		public ReadOnlyCollection<String> Files
		{
			get { return new ReadOnlyCollection<String>(_files); }
		}
		public PowerBuilderConfigParser()
		{
			_files = new List<string>();
		}
		public void ReadConfigFile(String path)
		{
			using (FileStream stream = new FileStream(path, FileMode.Open))
			{
				XmlReader reader = XmlReader.Create(stream);
				ReadVersionNumber(reader);
				ReadFiles(reader);
			}
		}
		private void ReadVersionNumber(XmlReader reader)
		{
			reader.ReadToDescendant("Version");
			string version = reader.ReadString();
			Int32 versionNumber;
			if (Int32.TryParse(version, out versionNumber))
			{
				Version = versionNumber;
			}
		}
		private void ReadFiles(XmlReader reader)
		{
			reader.ReadToNextSibling("Files");
			reader.ReadToDescendant("File");
			do
			{
				_files.Add(reader.ReadString());
			} while (reader.ReadToNextSibling("File"));
		}
	}
