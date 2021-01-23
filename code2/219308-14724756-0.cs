    // TextFieldParser is in the Microsoft.VisualBasic.FileIO namespace.
    using (TextFieldParser parser = new TextFieldParser(path))
    {
        parser.CommentTokens = new string[] { "#" };
        parser.SetDelimiters(new string[] { ";" });
        parser.HasFieldsEnclosedInQuotes = true;
 
        // Skip over header line.
        parser.ReadLine();
 
        while (!parser.EndOfData)
        {
            string[] fields = parser.ReadFields();
            yield return new Brand()
            {
                Name = fields[0],
                FactoryLocation = fields[1],
                EstablishedYear = int.Parse(fields[2]),
                Profit = double.Parse(fields[3], swedishCulture)
            };
        }
    }
