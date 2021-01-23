    public void Load (string fileName)
    {
        var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        var reader = new StreamReader(stream, Encoding.UTF8, true);
        var xmlString = reader.ReadToEnd();
        if (!string.IsNullOrWhiteSpace(xmlString)) {  // Use (xmlString.Trim().Length == 0) for .NET < 4
            var xml = XElement.Parse(xmlString);    // Exceptions will bubble up
            doStuff(xml);
        }
        tidyUp();
    }
