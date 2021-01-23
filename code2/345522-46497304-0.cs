    public class Foo
    {
        [XmlAnyElement("VersionComment")]
        public XmlComment VersionComment { get { return new XmlDocument().CreateComment("The application version, NOT the file version!"); } set { } }
        public string Version { get; set; }
        public string Name { get; set; }
    }
