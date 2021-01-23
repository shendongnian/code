    public static System.Object GetItemByID(System.Type type, int UID) 
    {
        Type ex = typeof(YourClass);
        MethodInfo mi = ex.GetMethod("GetItemByID");
        MethodInfo miConstructed = mi.MakeGenericMethod(type);
        // Invoke the method.
        object[] args = new[] {UID};
        return miConstructed.Invoke(null, args);
    }
