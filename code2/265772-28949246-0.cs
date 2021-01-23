      public class MySerializableClass
      {   
        [XmlIgnore]
        public string NaughtyXmlCharactersAsString { get; set; }
        [XmlElement(ElementName = "NaughtyXmlCharacters", DataType = "hexBinary")]
        public byte[] NaughtyXmlCharactersAsBytes
        {
            get { return Encoding.UTF8.GetBytes(NaughtyCharactersAsString ?? string.Empty); }
            set { NaughtyXmlCharactersAsString = Encoding.UTF8.GetString(value); }
        }
      
