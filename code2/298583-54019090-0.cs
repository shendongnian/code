    var parser = new POParser();
    POParseResult result;
    using (var reader = new StreamReader("sample.po", Encoding.UTF8))
        result = parser.Parse(reader);
    if (result.Success)
    {
        POCatalog catalog = result.Catalog;
        // process the parsed data...
    }
    else
    {
        IDiagnostics diagnostics = result.Diagnostics;
        // examine diagnostics, display an error, etc...
    }
