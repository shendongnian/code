      using System.Xml;
    
      public class XMLItemList
      {
        XmlElement el;
        XmlDocument doc;
    
        public XMLItemList()
        {
          doc = new XmlDocument();
          el = doc.CreateElement("items");
        }
    
        public void AddItem(string item)
        {
          var itemXml = doc.CreateElement("item");
          var attr = doc.CreateAttribute("id");
          attr.Value = item;
          itemXml.Attributes.Append(attr);
          el.AppendChild(itemXml);
        }
    
        public override string ToString()
        {
          return el.OuterXml;
        }
      }
