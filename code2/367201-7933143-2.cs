    void Deserialize() 
    {
        SomeModel myModel;
        try 
        {
            BinaryFormatter formatter = new BinaryFormatter();
    
            // Deserialize the object from the stream and 
            // assign the reference to the local variable.
            myModel = (SomeModel) formatter.Deserialize(ns);
        }
        catch (SerializationException e) 
        {
            throw e;
        }
    }
