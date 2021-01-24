    ```
	[DataContract]
	public class AppSetting
	{
		[DataMember(Name = "DataSource")]
		private string _dataSource;
		[DataMember(Name = "IntitialCatalog")]
		private string _intitialCatalog;
		[DataMember(Name = "UserId")]
		private string _userId;
		[DataMember(Name = "Password")]
		private string _password;
		// Remainder unchanged
    ```
    Then modify `XmlReader` as follows:
		public static void WriteAppSettingsToXmlFile(AppSetting appSetting)
		{
			var serializer = new DataContractSerializer(typeof(AppSetting));
			using (var stream = new FileStream(GlobalConstants.XmlFile, FileMode.Create))
			{
				serializer.WriteObject(stream, appSetting);
			}
		}
		public static AppSetting GetAppSettingsFromXmlFile()
		{
			if (!File.Exists(GlobalConstants.XmlFile))
			{
				return new AppSetting();
			}
			using (var stream = File.OpenRead(GlobalConstants.XmlFile))
			{
				var serializer = new DataContractSerializer(typeof(AppSetting));
				return (AppSetting)serializer.ReadObject(stream);
			}
		}
    The resulting properties will all be encrypted.
    Demo fiddle #2 [here](https://dotnetfiddle.net/XnPO1Q).
