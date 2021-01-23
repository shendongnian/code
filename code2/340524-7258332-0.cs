    public object ByteArrayToObject(byte[] byteArray)
    {
        try
        {
            // convert byte array to memory stream
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(byteArray);
    	 
            // create new BinaryFormatter
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter
    	                    = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    	 
            // set memory stream position to starting point
            memoryStream.Position = 0;
    	 
            // Deserializes a stream into an object graph and return as a object.
            return binaryFormatter.Deserialize(memoryStream);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught in process: {0}", ex.ToString());
        }
        return null;
    }
