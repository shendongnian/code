    public StreamReader GetResourceStream(string filename)
    {
        return new StreamReader(GetType().Assembly
                                         .GetManifestResourceStream(filename));
    }
    using (StreamReader resource = GetResourceStream("blah.xml"))
    {
        // Do stuff
    }
