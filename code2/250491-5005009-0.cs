    public T Create<T>(string s) where T : IDoWork 
    {
        IDoWork newUnit;
        s = string.Format("{0}.{1}", this.GetType().Namespace, s);
        newUnit = (T)System.Activator.CreateInstance(Type.GetType(s));
        return (T)newUnit;
    }
