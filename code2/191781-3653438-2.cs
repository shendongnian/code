    [XmlRoot(ElementName = "sgr")]
    public class SongGroup
    {
        public SongGroup()
        {
           this.Songs = new List<Song>();
        }
    
    [XmlElement(ElementName = "sgs")]
        public List<Song> Songs { get; set; }
    }
    
    [XmlRoot(ElementName = "g")]
    public class Song
    {
        [XmlElement("a")]
        public string Artist { get; set; }
    
        [XmlElement("s")]
        public string SongTitle { get; set; }
    } 
