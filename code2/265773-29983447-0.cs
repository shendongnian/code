    public class MySerializableClass
    {
        private string dummy;
       
        [XmlElement("NaughtyXmlCharacters")]
        public string NaughtyXmlCharactersAsString
        {
           get 
           {
               return BitConverter.ToString(NaughtyXmlCharacters);
           }
           set
           {
               // without this, the property is not serialized.
               dummy = value;
           }
        }
    
        [XmlIgnore]
        public byte[] NaughtyXmlCharacters
        {
            get;
            set;
        }
    }
