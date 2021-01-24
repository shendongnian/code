    Dictionary<string, object> myListA = new Dictionary<string, object>();
    Dictionary<string, object> myListB = new Dictionary<string, object>();
    
    public object GetDetails(string ID)
    {
        object a = myListA[ID];
        object b = myListB[ID];
    
        // combine them here how you want
        // object c = a + b;
    
        return c;
    }
