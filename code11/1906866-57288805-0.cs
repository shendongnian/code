    string[] lines = File.ReadAllLines("csvFile.csv");
    List<string[]> csvData = new List<string[]>();
    foreach(string line in lines)
    {
        using (TextFieldParser parser = new TextFieldParser(new StringReader(line)))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = true;
            parser.TrimWhiteSpace = true;
            while (!parser.EndOfData)
                csvData.Add(parser.ReadFields());
        }
    }
    
    //Select all lines in csv file in which third column are not empty
    List<string[]> filteredCsvData = csvData.Where(x => !string.IsNullOrWhiteSpace(x[2])).ToList();
    StringBuilder builder = new StringBuilder();
    foreach (string[] line in filteredCsvData)
    {
        //Quote all columns back
        string[] quotedLine = Array.ConvertAll(line, x => '"' + x + '"');
        builder.AppendLine(string.Join(',', quotedLine));
    }
    File.WriteAllText ("newCsvFile.csv", builder.ToString());
