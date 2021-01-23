    var settings = new Dictionary<string, object>();
    settings.Add("marsupial", wombat);
    
    BinaryFormatter formatter = new BinaryFormatter();
    var store = IsolatedStorageFile.GetUserStoreForAssembly();
    
    // Save
    using (var stream = store.OpenFile("settings.cfg", FileMode.OpenOrCreate, FileAccess.Write))
    {
        formatter.Serialize(stream, settings);
    }
    
    // Load
    using (var stream = store.OpenFile("settings.cfg", FileMode.OpenOrCreate, FileAccess.Read))
    {
        settings = (Dictionary<string, object>)formatter.Deserialize(stream);
    }
    wombat = (string)settings["marsupial"];
