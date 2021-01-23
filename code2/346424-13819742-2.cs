        public static XmlLoggingConfiguration SetNlogConfiguration()
        {
            var sr = new StringReader(NlogXmlConfigString1());
            var xr = XmlReader.Create(sr);
            var config = new XmlLoggingConfiguration(xr, null);
            return config;
        }
