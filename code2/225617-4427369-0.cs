    var serializedEnquetes = XDocument.Parse(serializedXml);
    IEnumerable<string> names = serializedEnquetes
                                    .Descendants("Enquete")
                                    .Attributes("Name")
                                    .Select(a => a.Value);
