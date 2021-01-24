        using System.Runtime.Serialization.Formatters.Binary;  
    
        ...
        LevelData[,] levelData = new LevelData[X,Y]{ .... };
        BinaryFormatter bf = new BinaryFormatter();  
        MemoryStream ms = new MemoryStream();  
        bf.Serialize(ms, theArray);  
