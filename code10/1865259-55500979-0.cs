    if (Application.platform != RuntimePlatform.Android)
    {
        testconnectionString = Path.Combine(Application.dataPath, "ARMaze.sqlite");
    }
    else
    {
        testconnectionString = Path.Combine(Application.persistentDataPath, "ARMaze.sqlite");
        ...
        
