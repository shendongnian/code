    class CoverageInfo {
        [XmlElement("ClassName")]
        public string className;
        [XmlElement("BlockCovered")]
        public int blocksCovered;
        [XmlElement("BlocksNotCovered")]
        public int blocksNotCovered;
    
        ....
    }
