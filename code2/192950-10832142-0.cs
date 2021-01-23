    public class LocalizationData
    {
        private static bool IsXML(string fileName)
        {
            return (fileName != null && fileName.ToLower().EndsWith("xml"));
        }
    
        public XmlDataProvider LoadFile(string fileName)
        {
            if (!IsXML(fileName)) return null*;
            return new XmlDataProvider{
                                         IsAsynchronous = false,
                                         Source = new Uri(fileName, UriKind.Absolute)
                                      };
        }
    }
