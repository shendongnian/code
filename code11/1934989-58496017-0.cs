    public class Country
    {
        public string Name { get; set; }
        public string Flag { get; set; }
    }
    
    public class LabelSetting
    {
        public List<string> Name { get; set; }
        public List<Settings> SettingsList { get; set; }
    }
    
    public class Settings
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public List<string> Label { get; set; }
    }
