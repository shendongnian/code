    public static void RequireField(string name, object field) 
    {
        if (field == null) Debug.LogError($"{name} field is unset");
    }
    public static void RequireField(string name, Object field) 
    {
        if (!field) Debug.LogError($"{name} field is unset");
    }
    
