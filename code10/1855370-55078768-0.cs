    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><!DOCTYPE beer PUBLIC \"-//BEER//DTD beer DTD version 2.0//KF//XML\" \"Kingfisher.dtd\"><root></root>";
                XDocument doc = XDocument.Parse(xml);
                XDocumentType _type  =  (XDocumentType)doc.Nodes().Where(x => x.NodeType == XmlNodeType.DocumentType).FirstOrDefault();
                _type.SystemId = "C:/Beer/Kingfisher.dtd";
     
            }
        }
    }
