        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(EnvironmentNodeConfigurationParameters));
                EnvironmentNodeConfigurationParameters parameters = (EnvironmentNodeConfigurationParameters)serializer.Deserialize(reader);
                               
            }
        }
