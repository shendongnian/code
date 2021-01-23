    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                FileExtensions extensions = new FileExtensions();
                var deserializer = new System.Xml.Serialization.XmlSerializer(typeof(FileExtensions));
                FileStream fs = new FileStream(@"d:\temp\consoleapplication3\ConsoleApplication3\XMLFile1.xml", FileMode.Open);
                XmlReader reader = new XmlTextReader(fs);
                extensions = (FileExtensions)deserializer.Deserialize(reader);
            }
        }
    
        [XmlRoot("FileExtensions")]
        public class FileExtensions
        {
            public FileExtensions()
            {
            }
    
            [XmlElement("Text")]
            public Text Text { get; set; }
            [XmlElement("Script")]
            public Script Script { get; set; }
        }
    
        public class Text
        {
            [XmlElement("Extension")]
            public List<string> Extensions { get; set; }
        }
    
        public class Script
        {
            [XmlElement("Extension")]
            public List<string> Extensions { get; set; }
        }
    }
