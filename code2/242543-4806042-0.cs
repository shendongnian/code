    private static Dictionary<string, object> objDictionary = new Dictionary<string, object>();
    public static Boolean IsIt(String nameObject1, String nameObject2) 
    {
        return objDictionary[nameObject1].ReferenceEquals(objDictionary[nameObject2]);
    } 
