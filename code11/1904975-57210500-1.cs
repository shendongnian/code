    public class MediaContent
    {
        [XmlAttribute("url")]
        public string Url {  get; set; }
        [XmlAttribute("height")]
        public int Height {  get; set; }
        [XmlAttribute("width")]
        public int Width {  get; set; }
        [XmlAttribute("medium")]
        public string Medium { get; set; }
    }
