    public static T Get<T>() where T : class
    {
        string implName = Program.Settings[typeof(T).Name].ToString();
        var concrete = Activator.CreateInstance<T>(Type.GetType(implName));
    
        return concrete;
    }
