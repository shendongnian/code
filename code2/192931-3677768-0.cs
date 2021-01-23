    public XmlDataProvider LoadFile(string fileName, XmlProviderFactory factory)
        {
            if (IsValidFileName(fileName))
            {
                return factory.NewXmlDataProvider(fileName);
            }
            return null;
        }
