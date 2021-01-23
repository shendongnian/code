    public interface IXmlDataProviderFactory
    {
        XmlDataProvider Create(string fileName);
    }
    public class LocalizationData
    {
        private IXmlDataProviderFactory factory;
        public LocalizationData(IXmlDataProviderFactory factory)
        {
            this.factory = factory;
        }
        private bool IsValidFileName(string fileName)
        {
            return fileName.ToLower().EndsWith("xml");
        }
        public XmlDataProvider LoadFile(string fileName)
        {
            if (IsValidFileName(fileName))
            {
                XmlDataProvider provider = this.factory.Create(fileName);
                provider.IsAsynchronous = false;
                return provider;
            }
            return null;
        }
    }
