    [XmlRoot("results")]
    public class Results 
    {
      [XmlElement("item")]
      public List<Item> Items { get; set; }
    }
