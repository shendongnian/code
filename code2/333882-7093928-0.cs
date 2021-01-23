    public class Item
    {
      [XmlAttribute("ItemName")]
      public string Name { get; set; }   
      [XmlAttribute("Cost")]
      public decimal Cost { get; set; }   
      [XmlAttribute("Image")]
      public decimal Image { get; set; }   
    }
    [XmlRoot("items")]
    public class Items
    {
      [XmlArray("food")]
      [XmlArrayItem("item")]
      public List<Item> Food { get; set; }
      [XmlArray("snaks")]
      [XmlArrayItem("item")]
      public List<Item> Snacks { get; set; }
      [XmlArray("drinks")]
      [XmlArrayItem("item")]
      public List<Item> Drinks { get; set; }     
      [XmlArray("vitamins")]
      [XmlArrayItem("item")]
      public List<Item> Vitamins { get; set; }
    }
