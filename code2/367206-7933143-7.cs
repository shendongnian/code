     using(BinaryReader reader =
            new BinaryReader(ns))
     {
        try
        {
            SomeModel myModel = new SomeModel();
            myModel.Name = binReader.ReadString();
        }
        // If the end of the stream is reached before reading
        // the four data values, ignore the error and use the
        // default settings for the remaining values.
        catch(EndOfStreamException e)
        {
            Console.WriteLine("{0} caught and ignored. " +
                "Using default values.", e.GetType().Name);
        }
    }
