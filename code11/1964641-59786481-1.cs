        public class ConfigurationHandler
        {
         // full path should end with ../file.xml
         public string DefaultPath = "yourPath";
        public ConfigurationHandler(string path = "")
        {
            if (!File.Exists(DefaultPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(DefaultPath));
                FileStream file = File.Create(DefaultPath);
                file.Close();
                Configuration = new Configuration();
                SaveConfigurations(DefaultPath);
            }
        }
        public void SaveConfigurations(string configPath = "")
        {
            if (string.IsNullOrEmpty(configPath))
                configPath = DefaultPath;
            var serializer = new XmlSerializer(typeof(Configuration));
            using (TextWriter writer = new StreamWriter(configPath))
            {
                serializer.Serialize(writer, Configuration);
            }
        }
        public Configuration LoadConfigurations(string configPath = "")
        {
            if (string.IsNullOrEmpty(configPath))
                configPath = DefaultPath;
            using (Stream reader = new FileStream(configPath, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                Configuration = (Configuration)serializer.Deserialize(reader);
            }
            return Configuration;
        }
    }
