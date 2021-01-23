    public class Section
    {
      [XmlElement("question")]
      public List<Question> Questions {get; set;}
      public Section()
      {
         Questions = new List<Question>();
      }
    }
