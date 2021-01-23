    void Serialize() 
    {
        SomeModel myModel = new SomeModel()
        {
            Name = "mooo"
        };
    
        // Construct a BinaryFormatter and use it to serialize the data to the stream.
        BinaryFormatter formatter = new BinaryFormatter();
        try 
        {
            formatter.Serialize(ns, myModel);
        }
        catch (SerializationException e) 
        {
            throw e;
        }
    }
