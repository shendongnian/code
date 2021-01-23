    public static string Serialize<T>(T o)
    { 
        eConnectType<T> eConnect = new eConnectType<T>(); 
 
        T[] myMaster = { o }; 
 
        // Populate the eConnectType object with the schema object 
        eConnect.SomePropertyName = myMaster; 
 
        return MemoryStreamSerializer(eConnect); 
    } 
