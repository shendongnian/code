    DataObject retrievedData = (DataObject)Clipboard.GetDataObject();
    if (retrievedData == null)
        return;
    String[] formats = retrievedData.GetFormats();
    foreach (String format in formats)
    {
        Object contents = retrievedData.GetData(format);
        MemoryStream ms = contents as MemoryStream;
        Byte[] bContents = ms == null ? null : ms.ToArray();
        String sContents = contents as String;
        // Check if bContents and sContents are null here, and analyse their contents
        // ...
    }
