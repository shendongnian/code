    private void OpenSavedData(StreamReader strmReader, string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SavedData));
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.CloseInput = true;
        settings.IgnoreWhitespace = true;
        SavedData savedData = null;
        using (XmlReader xmlReader = XmlReader.Create(strmReader, settings))
        {
            savedData = serializer.Deserialize(xmlReader) as SavedData;
        }
        
        // Process data
    }
