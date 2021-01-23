    public string FilePath { get; set; }
    public Settings LoadSettings()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Settings));
        Settings settings = null;
        using(TextReader reader = new StreamReader(this.FilePath))
        {
            settings = (Settings)serializer.Deserialize(reader);
        }
        return settings;
    }
