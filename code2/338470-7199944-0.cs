    var readerSettings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
    using (var reader = XmlReader.Create(stream, readerSettings))
    {
        while (reader.Read())
        {
            var sysReader = reader.ReadSubtree();
            if (sysReader.Read())
            {
                var sys = XDocument.ReadFrom(sysReader) as XElement;
                // do something with sys
            }
        }
    }
