    public static string Serialize<T>(T o)
        {
            eConnectType e = new eConnectType();
            T[] myMaster = { o };
            // Populate the eConnectType object with the schema object 
            typeof(eConnectType).GetField(typeof(T).Name).SetValue(e, myMaster);
            return MemoryStreamSerializer(e);
        }
