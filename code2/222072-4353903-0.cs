        public static XmlDocument GetEmbeddedXml(Assembly assembly, string fileName)
        {
            using (var str = GetEmbeddedFile(assembly, fileName))
            {
                using (var tr = new XmlTextReader(str))
                {
                    var xml = new XmlDocument();
                    xml.Load(tr);
                    return xml;
                }
            }
        }
        public static Stream GetEmbeddedFile(Assembly assembly, string fileName)
        {
            string assemblyName = assembly.GetName().Name;
            Assembly a = Assembly.Load(assemblyName);
            Stream str = a.GetManifestResourceStream(assemblyName + "." + fileName);
            if (str == null)
                throw new Exception("Could not locate embedded resource '" + fileName + "' in assembly '" + assemblyName + "'");
            return str;
        }
