    public static T CastInto<T>(object obj)
    {
        return (T)obj; 
        // return obj as T; // if you want to perform safe casting and you are ok with possible null values. Adding type constraint (e.g. where T : class) is needed to use it.
    }
