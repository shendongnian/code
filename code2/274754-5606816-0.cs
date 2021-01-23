    private static void SaveToWriter(StreamWriter writer)
    {
        // get saveData somehow
        writer.WriteLine(saveData);
    }
    
    // ...
    
    SaveData(filename, SaveToWriter);
