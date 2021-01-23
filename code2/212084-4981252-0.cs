		[ClassInitialize]
		public static void MyClassInitialize(TestContext testContext)
		{
			System.Configuration.Moles.MConfigurationManager.GetSectionString =
				(string configurationName) =>
					{
						ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
						Assembly assembly = Assembly.GetExecutingAssembly();
						fileMap.ExeConfigFilename = assembly.Location + ".config";
						Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
						object section = config.GetSection(configurationName);
						if (section is DefaultSection)
						{
							ConfigurationSection configurationSection = (ConfigurationSection) section;
							Type sectionType = Type.GetType(configurationSection.SectionInformation.Type);
							if (sectionType != null)
							{
								IConfigurationSectionHandler sectionHandler =
									(IConfigurationSectionHandler)AppDomain.CurrentDomain.CreateInstanceAndUnwrap(sectionType.Assembly.FullName, sectionType.FullName);
								section = 
									sectionHandler.Create(
										configurationSection.SectionInformation.GetParentSection(), 
										null,
										XElement.Parse(configurationSection.SectionInformation.GetRawXml()).ToXmlNode());
							}
						}
						return section;
					};
		}
