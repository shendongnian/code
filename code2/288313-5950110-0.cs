    string line = textReader.ReadLine();
    var reader = new StringReader(line);
    while (line != null)
    {
        var ip = reader.ReadWord();
        reader.SkipWhitespaces();
        var date = reader.ReadQuotedString();
        reader.SkipWhitespaces();
        var uri = reader.ReadQuotedString();
        reader.ReadUntil('"');
        var uri2 = reader.ReadQuotedString();
        line = textReader.ReadLine();
        reader.Assign(line);
    }
        
