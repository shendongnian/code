    [XmlRoot]
    public class Configuration
    {
        [XmlElement("Devices")]
        public List<Devices> deviceList = new List<Devices>();
    }
    public class Devices
    {
        [XmlElement("Settings")]
        public List<Settings> settingList = new List<Settings>();
    }
    public class Settings
    {
        public string Name { get; set; }
        public string HostNic { get; set; }
    }
