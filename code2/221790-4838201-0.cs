        public class MyConfig : ConfigurationSection
        {
            private static MyConfig _current;
            public static MyConfig Current
            {
                get
                {
                    if (_current == null)
                    {
                        switch(ConfigurationStorageType) // where do you want read config from?
                        {
                            case ConfigFile: // from .config file
                                _current = ConfigurationManager.GetSection("MySectionName") as MyConfig;
                                break;
                            case ConfigDb: // from database
                            default:
                                using (Stream stream = GetMyStreamFromDb())
                                {
                                    using (XmlTextReader reader = new XmlTextReader(stream))
                                    {
                                        _current = Get(reader);
                                    }
                                }
                                break;
                        }
                    }
                    return _current;
                }
            }
            public static MyConfig Get(XmlReader reader)
            {
                if (reader == null)
                    throw new ArgumentNullException("reader");
                MyConfig section = new MyConfig();
                section.DeserializeSection(reader);
                return section;
            }
        }
