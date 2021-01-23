    public void Load (string fileName)
    {
        var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        var reader = new StreamReader(stream, Encoding.UTF8, true);
        var xmlString = reader.ReadToEnd();
        XElement xml = null;
        if (!string.IsNullOrWhiteSpace(xmlString)) {
            xml = XElement.Parse(xmlString);    // Exceptions will bubble up
        }
        if (xml != null) {
            doStuff (xml);
        }
        tidyUp ();
    }
