    public IEnumerable<string> GetInfo() 
    {
        // make command and reader...
        while(reader.Read() 
        {
            yield return reader.GetString("info");
        }
     }
