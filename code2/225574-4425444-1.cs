    public static T Get<T>() where T : class
    {
        string implName = Program.Settings[typeof(T).Name].ToString();
        var implType = Type.GetType(implName);
        return (T)Activator.CreateInstance(implType);
    }
