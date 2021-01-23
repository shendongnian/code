    using System.Configuration;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Xml.XPath;
    
    namespace Ariel.Configuration
    {
        class XmlSerializerSectionHandler : IConfigurationSectionHandler
        {
            public object Create(object parent, object configContext, XmlNode section)
            {
                XPathNavigator nav = section.CreateNavigator();
                string typename = (string)nav.Evaluate("string(@type)");
                Type t = Type.GetType(typename);
                XmlSerializer ser = new XmlSerializer(t);
                return ser.Deserialize(new XmlNodeReader(section));
            }
        }
    }
