    using System.IO;
    using System.Xml.Serialization;
    
    namespace AnXmlSample
    {
      
      class Program
      {
        static void Main( string[] args )
        {
          string xml = @"<document id='3'>
                           <name>
                             document name
                           </name>
                           <foo widget-id='12' >
                             The quick brown fox jumped over the lazy dog
                           </foo>
                         </document>" ;
          StringReader sr = new StringReader(xml) ;
          XmlSerializer serializer = new XmlSerializer(typeof(MyDataFromXml)) ;
          MyDataFromXml instance = (MyDataFromXml) serializer.Deserialize( sr ) ;
          
          return ;
        }
      }
      
      [XmlRoot("document")]
      public class MyDataFromXml
      {
        [XmlAttribute("id")]
        public int Id { get ; set ; }
        
        [XmlElement("name")]
        public string Name { get ; set ; }
        
        [XmlElement("foo")]
        public Widget Foo { get ; set ; }
        
      }
      
      public class Widget
      {
        [XmlAttribute("widget-id")]
        public int id { get ; set ; }
        
        [XmlText]
        public string Content { get ; set ; }
      }
      
    }
