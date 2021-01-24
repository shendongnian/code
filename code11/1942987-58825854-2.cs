		public static void WriteAppSettingsToXmlFile(AppSetting appSetting)
		{
			var xs = new XmlSerializer(typeof(AppSetting));
			using (var tw = new StreamWriter(GlobalConstants.XmlFile))
			{
				xs.Serialize(tw, appSetting);
			}
		}
