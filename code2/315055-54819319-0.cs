    public static void DisposeAll(this IEnumerable clx) {
        foreach (Object obj in clx) 
        {
            IDisposable disposeable = obj as IDisposable;
            if (disposeable != null) 
                disposeable.Dispose();
        }
    }
    
    usersCollection.DisposeAll();
    usersCollection.Clear();
