    List<string> foundLines = new List<string>();
    using (TextFieldParser parser = new TextFieldParser(inputFilename))
    {
        // Set up the parser for CSV files
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        using (StreamWriter writer = new StreamWriter(outputFilename, false))
        {
            while (!parser.EndOfData)
            {
                string[] values = parser.ReadFields();
                string serialNumber = values[0];
                if (string.Equals(serialNumber, "XA2345"))
                {
                    string line = string.Join(",", values.Select(Escape));
                    if (foundLines.Contains(line))
                        continue; // Skip writing this line more than once
                    else
                        foundLines.Add(line); // Remember this line for later
                    writer.WriteLine(line);
                    // Do what you need to with the individual column values
                    string secondValue = values[1];
                    string thirdValue = values[2];
                    // ... Etc. ...
                }
            }
        }
    }
