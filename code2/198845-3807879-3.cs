      [XmlRoot("FooList")]
      public class CollectionWrapper
      {
         [XmlElement]
         public List<Foo> Items { get; set; }
         public string SomeMessage { get; set; }
      }
