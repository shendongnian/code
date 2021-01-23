    using (var streamReader = new StreamReader(fileName))
    {
        string line;
        while ((line = streamReader.ReadLine()) != null)
        {
            // analize line here
            // throw it away if it does not match
        }
    }
