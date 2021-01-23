    using System;
    using System.Xml;
    using System.Text.RegularExpressions;
    
    class Sample {
        static void Main(string[] args) {
            var doc = new XmlDocument();
            doc.Load(@"data.xml");
            XmlNodeList  nodes = doc.SelectNodes("/Adresses/*/XPath");
            Regex regex = new Regex(@"Local\[\d{3}\]");
            foreach(XmlNode  node in nodes){
                node.InnerText = regex.Replace(node.InnerText, "Local[001]");
            }
            doc.Save(@"data.xml");
        }
    }
