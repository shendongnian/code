    using System;
    using System.Xml;
    using System.Xml.XPath;
    
    class Sample {
        static void Main(string[] args){
            string xmlCode = @"<content:encoded><![CDATA[<div xmlns='http://www.w3.org/1999/xhtml'><div class=""separator"" style=""clear: both; text-align: center;""><a href=""http://site.com/images/image.jpg"" imageanchor=""1"" style=""clear: left; float: left; margin-bottom: 1em; margin-right: 1em;""><img border=""0"" src=""http://site.com/image.jpeg""/></a></div></div>]]></content:encoded>";
            xmlCode = @"<root xmlns:content=""http://www.w3.org/1999/xhtml"">" + xmlCode + "</root>";
            var RSSXml = new XmlDocument();
            RSSXml.LoadXml(xmlCode);
            var namespaceManager = new XmlNamespaceManager(RSSXml.NameTable);
    
            namespaceManager.AddNamespace("content", "http://www.w3.org/1999/xhtml");
    
            XmlNode node = RSSXml.SelectSingleNode("//content:encoded", namespaceManager);
            Console.WriteLine(node.InnerText);//CDATA
            
            RSSXml.LoadXml(node.InnerText);
            namespaceManager = new XmlNamespaceManager(RSSXml.NameTable);
            namespaceManager.AddNamespace("ns", "http://www.w3.org/1999/xhtml");
            var href = RSSXml.SelectSingleNode("//ns:div/ns:a/@href", namespaceManager);
            Console.WriteLine(href.Value);
        }
    }
