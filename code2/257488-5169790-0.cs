    using System;
    using System.Xml;
    
    class Test
    {
         static void Main(string[] args)
         {
              XmlWriter xmlWriter = XmlWriter.Create("MyXml.xml");
              XmlTextWriter xmlTextWriter = xmlWriter as XmlTextWriter;
              if(xmlTextWriter != null)
              {
                   //perform operations here...
              }
         }   
    }
