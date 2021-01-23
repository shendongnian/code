    public sealed class XmlConfigurator : IConfigurationSectionHandler
    {
        public XmlConfigurator()
        {
        }
        public object Create(object parent, object configContext, XmlNode section)
        {
            XPathNavigator navigator = null;
            String typeName = null;
            Type sectionType = null;
            XmlSerializer xs = null;
            XmlNodeReader reader = null;
 
            try
            {
                Object settings = null;
                if (section == null)
                {
                    return settings;
                }
                navigator = section.CreateNavigator();
                typeName = (string)navigator.Evaluate("string(@type)");
                sectionType = Type.GetType(typeName);
                xs = new XmlSerializer(sectionType);
                reader = new XmlNodeReader(section);
                settings = xs.Deserialize(reader);
                return settings;
            }
            finally
            {
                xs = null;
            }
        }
    }
