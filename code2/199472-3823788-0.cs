    [XmlRoot("Book")]
    public class Book
    {
       [XmlAttribute]
       public string Title;
    
       [XmlElement]
       public Publisher Publisher;
    }
    
    [Serializable]
    public class Publisher
    {
      [XmlText]
      public string Value;
      
      [XmlAttribute]
      public string Reference;
    }
