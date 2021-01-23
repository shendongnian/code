    private static void DownloadThreadsComplete(object sender, DownloadStringCompletedEventArgs e)
    {
        XDocument doc;
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.DtdProcessing = DtdProcessing.Ignore;
        using (XmlReader reader = XmlReader.Create(e.Result, settings))
        {
             doc = XDocument.Load(reader);
        }
        // Do stuff with doc
    }
