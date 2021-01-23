    class FakeXmlDataProviderFactory : IXmlDataProviderFactory
    {
        public XmlDataProvider ProviderToReturn { get; set; }
        public XmlDataProvider Create(string fileName)
        {
            return this.ProviderToReturn;
        }
    }
