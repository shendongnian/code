    public static void RequireField(string name, object field) 
    {
        if (field == null) Debug.Log($"{name} field is unset");
    }
    public static void RequireField(string name, Object field) 
    {
        if (!field) Debug.Log($"{name} field is unset");
    }
    
