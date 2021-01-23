    using (TextReader textReader = ...)
    using (TextWriter textWriter = ...)
    {
        string line;
    
        while ((line = textReader.ReadLine()) != null)
        {
            // split into columns here
            string[] columns = ...;
            foreach (string column in columns)
            {
                textWriter.WriteLine(column);
            }
        }
    }
