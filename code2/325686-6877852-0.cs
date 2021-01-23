        <items name ="something 1" >
          <subitems name ="sub something1" >
            <item name="item 1" />
            <item name="item 2" />
            <item name="item 3" />
            <someOtherTag name="Come On Really" />
          </subitems>
        </items>
    For this option, here's **a class** that will serialize/deserialize the above markup (one should note that, as they say in the Perl world, "TMTOWTDI" (_There's more than one way to do it_):
          [XmlRoot( "items" )]
          public class Widget
          {
            
            [XmlAttribute("name")]
            public string Name { get ; set ; }
            
            [XmlElement( "subitems" )]
            public SubWidget SubItems { get ; set ; } 
            
            public class SubWidget
            {
              
              [XmlAttribute("name")]
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
