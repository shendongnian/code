     private const string filePath = "TimeKeeperData.xml";
        private static XDocument ReadDataFromIsolatedStorageXmlDoc()
        {
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!storage.FileExists(filePath))
                {
                    return new XDocument();
                }
                using (var isoFileStream = new IsolatedStorageFileStream(filePath, FileMode.OpenOrCreate, storage))
                {
                    using (XmlReader reader = XmlReader.Create(isoFileStream))
                    {
                        return XDocument.Load(reader);
                    }
                }
            }
        }
