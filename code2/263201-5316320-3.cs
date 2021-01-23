    using(FileStream fs = File.OpenRead(FileName)) {
    try
    	{
    		BinaryFormatter bf = new BinaryFormatter();
    		var list = (List<int>)bf.Deserialize(fs);
    	}
    	catch (SerializationException)
    	{
    		// Error handling
    	}
    }
