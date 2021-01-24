    [Serializable, XmlRoot("Config")]
    public class Config
    {
        public UI UI { get; set; }
        public Output Output { get; set; }
    }
    public struct UI
    {
        public string Colour { get; set; }
        public string Size { get; set; }
    }
    public struct Output
    {
        public string Mode { get; set; }
        public int Version { get; set; }
    }
