        using System.Runtime.Serialization.Formatters.Binary;  
    
        ...
        bool[,] unlockedLevels = new bool[X,Y]{....};
        BinaryFormatter bf = new BinaryFormatter();  
        MemoryStream ms = new MemoryStream();  
        bf.Serialize(ms, theArray);  
