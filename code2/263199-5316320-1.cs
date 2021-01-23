    FileStream fs;
    try
    {
        fs = File.OpenRead(FileName);
        BinaryFormatter bf = new BinaryFormatter();
        var list = (List<int>)bf.Deserialize(fs);
    }
    catch (SerializationException)
    {
        // Error handling
    }
    finally
    {
        if (fs != null)
            fs.Close();
    }
