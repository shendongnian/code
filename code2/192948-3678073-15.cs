    class ProductionXmlDataProviderFactory : IXmlDataProviderFactory
    {
        public XmlDataProvider Create(string fileName)
        {
            return new XmlDataProvider
            {
                Source = new Uri(fileName, UriKind.Absolute)
            };
        }
    }
