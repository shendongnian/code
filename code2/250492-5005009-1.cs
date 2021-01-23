    public T Create<T>(string s) where T : IDoWork 
    {
        IDoWork newUnit;
        string fullClassname = string.Format("{0}.{1}", this.GetType().Namespace, s);
        newUnit = (T)System.Activator.CreateInstance(Type.GetType(fullClassname));
        return (T)newUnit;
    }
