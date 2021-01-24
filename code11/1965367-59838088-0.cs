    using var fileStream = new FileStream(@"crg_sample.crg", FileMode.Open, FileAccess.Read);
    using var reader = new BinaryReader(fileStream);
    var newLine = '\n';
    var markerString = "$$$$";
    var currentString = "";
    var foundMarker = false;
    var foundNewLine = false;
    while (!foundNewLine)
    {
        var c = reader.ReadChar();
        if (!foundMarker)
        {
            currentString += c;
            if (currentString.Length > markerString.Length)
                currentString = currentString.Substring(1);
            if (currentString == markerString)
                foundMarker = true;
        }
        else
        {
            if (c == newLine)
                foundNewLine = true;
        }
    }
    if (foundNewLine)
    {
        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            // Read binary
        }
    }
