    /// <summary>
    /// Represents a log file in isolated storage.
    /// </summary>
    public static class Log
    {
        private const string FileName = "TestLog.xml";
        private static IsolatedStorageFile isoStore;
        private static IsolatedStorageFileStream logWriterFileStream;
        private static StreamWriter logWriter;
        public static XDocument Xml { get; private set; }
        static Log()
        {
            isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            logWriterFileStream = isoStore.OpenFile(
                FileName, 
                FileMode.Create, 
                FileAccess.Write, 
                FileShare.None);
            logWriter = new StreamWriter(logWriterFileStream);
            logWriter.AutoFlush = true;
            Xml = new XDocument(new XElement("Tests"));
        }
        /// <summary>
        /// Writes a snapshot of the test log XML to isolated storage.
        /// </summary>
        public static void Write(XElement testContextElement)
        {
            Xml.Root.Add(testContextElement);
            logWriter.BaseStream.SetLength(0);
            logWriter.Write(Xml.ToString());
        }
    }
