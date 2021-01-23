    using System.Xml;
    public class TestClass
    {
        void ParseXML(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList list = doc.GetElementsByTagName("EXPR");
        }
    }
