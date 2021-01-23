    var readerSettings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
    using (var reader = XmlReader.Create(stream, readerSettings))
    {
        while (reader.Read())
        {
            using (var fragmentReader = reader.ReadSubtree())
            {
                if (fragmentReader.Read())
                {
                    var fragment = XNode.ReadFrom(fragmentReader) as XElement;
                    // do something with fragment
                }
            }
        }
    }
