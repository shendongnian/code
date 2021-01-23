    var doc = XDocument.Parse(@"<root>
      <person id=""0"">
        <a1>val</a1>
        <a2>val</a2>
      </person>
      <person id=""1"">
        <a1>val</a1>
        <a2>val</a2>
      </person>
    </root>");
    var result = doc.Root
                    .Elements()
                    .ToDictionary(
                        e => e.Attribute("id"),
                        e => e.Elements()
                              .ToDictionary(
                                  f => f.Name.LocalName,
                                  f => f.Value));
