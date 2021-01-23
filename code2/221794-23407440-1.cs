	public class TestSettings : ConfigurationSection
	{
		protected override void DeserializeSection(System.Xml.XmlReader reader)
		{
			using (DbConnection conn = /* Get an open database connection from whatever provider you are using */)
			{
				DbCommand cmd = conn.CreateCommand();
				cmd.CommandText = "select ConfigFileContent from Configuration where ConfigFileName = @ConfigFileName";
				DbParameter p = cmd.CreateParameter();
				p.ParameterName = "@ConfigFileName";
				p.Value = "TestSettings.config";
				cmd.Parameters.Add(p);
				String xml = (String)cmd.ExecuteScalar();
				using(System.IO.StringReader sr = new System.IO.StringReader(xml))
				using (System.Xml.XmlReader xr = System.Xml.XmlReader.Create(sr))
				{
					base.DeserializeSection(xr);
				}                
			}            
		}
		// Below is all your normal existing section code
		
		[ConfigurationProperty("General")]
		public GeneralElement General { get { return (GeneralElement)base["General"]; } }
		[ConfigurationProperty("UI")]
		public UIElement UI { get { return (UIElement)base["UI"]; } }
		
		...
		
		...
	}
