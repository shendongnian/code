public class MySettings
		{
			public string Setting1 { get; set; }
			public List<string> Setting2 { get; set; }
			public void Save(string filename)
			{
				using (StreamWriter sw = new StreamWriter(filename))
				{
					XmlSerializer xmls = new XmlSerializer(typeof(MySettings));
					xmls.Serialize(sw, this);
				}
			}
			public MySettings Read(string filename)
			{
				using (StreamReader sw = new StreamReader(filename))
				{
					XmlSerializer xmls = new XmlSerializer(typeof(MySettings));
					return xmls.Deserialize(sw) as MySettings;
				}
			}
		}
