    public class Settings
    {
        public string Setting1 { get; set; }
        public int Setting2 { get; set; }
    }
    static void SaveSettings(Settings settings)
    {
        var serializer = new XmlSerializer(typeof(Settings));
        using (var stream = File.OpenWrite(SettingsFilePath))
        {
            serializer.Serialize(stream, settings);
        }
    }
    static Settings LoadSettings()
    {
        if (!File.Exists(SettingsFilePath))
            return new Settings();
        var serializer = new XmlSerializer(typeof(Settings));
        using (var stream = File.OpenRead(SettingsFilePath))
        {
            return (Settings)serializer.Deserialize(stream);
        }
    }
