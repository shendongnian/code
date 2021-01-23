    public class WoahWrapper
    {
        private List<Woah> woahs = new List<Woah>();
        [XmlArray("Woahs"), XmlArrayItem("WoahNode")]
        public List<Woah> Woahs { get { return woahs; } }
    }
    public class Woah
    {
        public int SomeChild { get; set; }
        private List<Woah> children;
        [XmlArray("SubWoahs"), XmlArrayItem("WoahNode")]
        public List<Woah> Children { get { return children ?? (
            children = new List<Woah>()); } }
    }
