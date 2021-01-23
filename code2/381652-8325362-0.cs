     [XmlRoot("FileExtensions")]
    public class FileExtensions
    {
        [XmlElement("Text")]
        public Text Text;
        [XmlElement("Script")]
        public Script Script;
    }
    public class Text
    {
        [XmlElement("Extension")]
        public List<Extensions> Texts;
        public Text()
        {
            Texts = new List<Extensions>();
        }
    }
    public class Script
    {
        [XmlElement("Extension")]
        public List<Extensions> Scripts;
        public Script()
        {
            Scripts = new List<Extensions>();
        }
    }
    public class Extensions
    {
        [XmlElement("Extension")]
        public string name;
    }
