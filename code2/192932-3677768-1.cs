    class XmlDataProviderFactory
    {
        public virtual XmlDataProvider NewXmlDataProvider(string fileName)
        {
           return  new XmlDataProvider
                       {
                           IsAsynchronous = false,
                           Source = new Uri(fileName, UriKind.Absolute)
                       };
    }
    
    class XmlDataProviderFactoryMock : XmlDataProviderFactory
    {
        public override XmlDataProvider NewXmlDataProvider(string fileName)
        {
            return new XmlDataProvider();
        }
    }
    
    public class LocalizationData
    {
    ...
        public XmlDataProvider LoadFile(string fileName, XmlDataProviderFactory factory)
            {
                if (IsValidFileName(fileName))
                {
                    return factory.NewXmlDataProvider(fileName);
                }
                return null;
            }
    }
    
    [TestFixture]
    class LocalizationDataTest
    {
        [Test]
        public void LoadFile_DataLoaded_Succefully()
        {
            var data = new LocalizationData();
            string fileName = "d:/azeri.xml";
            XmlDataProvider result = data.LoadFile(fileName, new XmlDataProviderFactoryMock());
            Assert.IsNotNull(result);
            Assert.That(result.Document, Is.Not.Null);
        }
    
    }
