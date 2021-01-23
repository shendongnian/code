    var reader = new FileReader ("input.cards");
    var writer = new FileWriter ("filtered.cards");
    var writeToOutput = true;
    while (! reader.EndOfStream)
    {
        var inputLine = reader.ReadLine ();
        if (inputLine.StartsWith ("####"))
        {
            // control line
            if (inputLine.Contains ("ID: 1"))
                writeToOutput = false;
            if (! writeToOutput && inputLine.Contains ("ENDCARD"))
                writeToOutput = true;
        }
        if (writeToOutput)
            writer.WriteLine (inputLine);
    }
