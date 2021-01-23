    public interface DataProvider
    {
        bool IsValidProvider();
        void DisableAsynchronousOperation();
    }
    public class XmlDataProvider : DataProvider
    {
        private string fName;
        private bool asynchronousOperation = true;
        public XmlDataProvider(string fileName)
        {
            fName = fileName;
        }
        public bool IsValidProvider()
        {
            return fName.ToLower().EndsWith("xml");
        }
        public void DisableAsynchronousOperation()
        {
            asynchronousOperation = false;
        }
    }
    
    public class LocalizationData
    {
        private DataProvider dataProvider;
        public LocalizationData(DataProvider provider)
        {
            dataProvider = provider;
        }
        public DataProvider Load()
        {
            if (provider.IsValidProvider())
            {
                provider.DisableAsynchronousOperation();
                return provider;
            }
            return null;
        }
    }
