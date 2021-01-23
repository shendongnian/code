    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    
    namespace ConsoleApplication1
    {
      [Serializable]
      [XmlRoot("MyXml")]
      public class MyClass
      {
        [XmlElement("Version")]
        public string Version { get; set; }
    
        [XmlElement("Resources")]
        public List<Resources> Resources { get; set; }
      }
    
      [Serializable]
      public class Resources
      {
        [XmlElement("Sets")]
        public List<Sets> Sets { get; set; }
      }
    
      [Serializable]
      public class Sets
      {
        [XmlArray(ElementName = "ItemCollection")]
        [XmlArrayItem("Item")]
        public List<Item> Items { get; set; }
      }
    
      [Serializable]
      public class Item
      {
        [XmlElement("Name")]
        public string Name { get; set; }
    
        [XmlElement("Age")]
        public string Age { get; set; }
      }
      
      class Program
      {
        static void Main(string[] args)
        {
          string xml = 
          @"<MyXml>
             <Version> 9.3.2 </Version>
             <Resources>      
               <Sets>
                 <ItemCollection>
                   <Item>
                     <Name> Name </Name>
                     <Age> 66 </Age>
                   </Item>
                 </ItemCollection>
               </Sets>
             </Resources>
           </MyXml>";
    
          MemoryStream str = new MemoryStream( UTF8Encoding.UTF8.GetBytes( xml ) );
    
          XmlSerializer s = new XmlSerializer(typeof(MyClass));
          var items = s.Deserialize( str ) as MyClass;
    
          Console.Write( "Done" );
    
        }
      }
    }
