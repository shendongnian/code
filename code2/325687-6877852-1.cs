        <items>
          <name>something 1</name>
          <subitems>
            <name>sub something1</name>
            <item name="item 1" />
            <item name="item 2" />
            <item name="item 3" />
            <someOtherTag name="Come On Really" />
          </subitems>
        </items>
    Again, **a class** that will serialize/deseraliaze this markup is virtually identical to the first case. All we do is change two attributes from `XmlAttribute` to `XmlElement`, thus:
        [XmlRoot( "items" )]
        public class Widget
        {
          
          [XmlElement("name")] // was XmlAttribute
          public string Name { get ; set ; }
          
          [XmlElement( "subitems" )]
          public SubWidget SubItems { get ; set ; } 
          
          public class  SubWidget
          {
            
            [XmlElement("name")] // was XmlAttribute
            public string Name { get ; set ; }
            
            [XmlElement("item")]
            public Element[] Item { get ; set ; }
            
            [XmlElement("someOtherTag")]
            public Element SomeOtherTag { get ; set ; }
            
            public class Element
            {
              
              [XmlAttribute("name")]
              public string Name { get ; set ; }
            }
             
          }
           
        }
