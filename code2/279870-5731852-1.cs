    private void LoadConfig()
            {
                try
                {
                    cm = new ConfigManager();
                    ser = new XmlSerializer(typeof(ConfigManager));
                    filepath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + cm.filepath;
    
                    if (File.Exists(filepath))
                    {
                        FileStream fs = new FileStream(filepath, FileMode.Open);
                        cm = (ConfigManager)ser.Deserialize(fs);
                        
                        // do something
                    }
                } catch (Exception ex) { }
          }
