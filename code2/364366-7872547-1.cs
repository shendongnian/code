    public class ConfigSectionHandler : IConfigurationSectionHandler
    {
        public const string SECTION_NAME = "MyConfig";
        public object Create(object parent, object configContext, XmlNode section)
        {
            string szConfig = section.SelectSingleNode("//MyConfig").OuterXml;
            MyConfig retConf = null;
    
            if (szConfig != string.Empty || szConfig != null)
            {
                XmlSerializer xsw = new XmlSerializer(typeof(MyConfig));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(szConfig));
                ms.Position = 0;
                retConf = (MyConfig)xsw.DeSerialize(ms);
            }
            return retConf;
        }
    
    }
